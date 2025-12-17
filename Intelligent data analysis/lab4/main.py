import pandas as pd
import numpy as np
import math
from itertools import combinations

class Node:
    def __init__(self, attribute=None, label=None, branches=None):
        self.attribute = attribute  # Атрибут, по якому ділимо
        self.label = label          # Якщо це листок - значення класу (Так/Ні)
        self.branches = branches or {} # Гілки {значення_атрибуту: Node}

def entropy(data, target_col):
    """Обчислення ентропії"""
    elements, counts = np.unique(data[target_col], return_counts=True)
    entropy = np.sum([(-counts[i]/np.sum(counts)) * np.log2(counts[i]/np.sum(counts)) for i in range(len(elements))])
    return entropy

def info_gain(data, split_attribute_name, target_name):
    """Обчислення приросту інформації (Gain)"""
    total_entropy = entropy(data, target_name)
    vals, counts = np.unique(data[split_attribute_name], return_counts=True)
    weighted_entropy = np.sum([(counts[i]/np.sum(counts)) * entropy(data.where(data[split_attribute_name]==vals[i]).dropna(), target_name) for i in range(len(vals))])
    return total_entropy - weighted_entropy

def id3(data, originaldata, features, target_attribute_name="Zdav", parent_node_class=None):
    """Рекурсивний алгоритм ID3 """
    if len(np.unique(data[target_attribute_name])) <= 1:
        return Node(label=np.unique(data[target_attribute_name])[0])
    
    elif len(data) == 0:
        return Node(label=parent_node_class)
    
    elif len(features) == 0:
        parent_node_class = np.unique(data[target_attribute_name])[np.argmax(np.unique(data[target_attribute_name], return_counts=True)[1])]
        return Node(label=parent_node_class)
    
    else:
        parent_node_class = np.unique(data[target_attribute_name])[np.argmax(np.unique(data[target_attribute_name], return_counts=True)[1])]
        item_values = [info_gain(data, feature, target_attribute_name) for feature in features]
        best_feature_index = np.argmax(item_values)
        best_feature = features[best_feature_index]
        
        tree = Node(attribute=best_feature)
        features = [i for i in features if i != best_feature]
        
        for value in np.unique(data[best_feature]):
            sub_data = data.where(data[best_feature] == value).dropna()
            subtree = id3(sub_data, originaldata, features, target_attribute_name, parent_node_class)
            tree.branches[value] = subtree
            
        return tree

def print_tree(node, indent=""):
    """Візуалізація дерева у текстовому форматі"""
    if node.label is not None:
        print(indent + "Result: " + str(node.label))
    else:
        print(indent + "[" + str(node.attribute) + "]")
        for value, child in node.branches.items():
            print(indent + "  -- " + str(value) + " -->")
            print_tree(child, indent + "    ")

def preprocess_data(df, target_col):
    print("\n--- Етап 1: Видалення дублікатів та суперечностей ---")
    df_clean = df.drop_duplicates()
    print("Дублікати видалено. Розмір:", df_clean.shape)

    feature_cols = [c for c in df.columns if c != target_col]
    
    contradictions = df_clean.groupby(feature_cols)[target_col].nunique()
    contradictions = contradictions[contradictions > 1]
    
    if not contradictions.empty:
        print("Знайдено суперечливі записи (Rough Area). Видалення...")
        df_clean = df_clean.drop_duplicates(subset=feature_cols, keep=False)
        print("Суперечності видалено. Залишилося рядків:", len(df_clean))
    else:
        print("Суперечностей не знайдено.")

    return df_clean

def get_reduct(df, target_col):
    """Метод Boolean Reasoning для пошуку редукта """
    print("\n--- Етап 2: Побудова матриці розрізнення та пошук редукта ---")
    features = [c for c in df.columns if c != target_col]
    n = len(df)
    
    discernibility_matrix = []
    
    df_reset = df.reset_index(drop=True)
    
    for i in range(n):
        for j in range(i + 1, n):
            if df_reset.loc[i, target_col] != df_reset.loc[j, target_col]:
                diffs = []
                for f in features:
                    if df_reset.loc[i, f] != df_reset.loc[j, f]:
                        diffs.append(f)
                if diffs:
                    discernibility_matrix.append(set(diffs))
    
    print(f"Побудовано пар для розрізнення: {len(discernibility_matrix)}")
    
    for k in range(1, len(features) + 1):
        for combo in combinations(features, k):
            combo_set = set(combo)
            if all(not cell.isdisjoint(combo_set) for cell in discernibility_matrix):
                print(f"Знайдено мінімальний редукт: {combo}")
                return list(combo)
    
    return features

if __name__ == "__main__":
    from io import StringIO
    csv_data = """Pidgotovka,Vidviduvannya,Shpargalky,Zdav
Dobre,Vysoke,Ye,Tak
Dobre,Vysoke,Ye,Tak
Pogano,Nyzke,Nema,Ni
Dobre,Nyzke,Ye,Tak
Dobre,Nyzke,Ye,Ni
Pogano,Vysoke,Nema,Ni
Dobre,Vysoke,Nema,Tak
"""
    df = pd.read_csv(StringIO(csv_data))
    print("Вхідна матриця:")
    print(df)
    
    df_consistent = preprocess_data(df, "Zdav")
    print("\nМатриця без суперечностей:")
    print(df_consistent)
    
    reduct_features = get_reduct(df_consistent, "Zdav")
    df_minimized = df_consistent[reduct_features + ["Zdav"]]
    
    print("\n--- Етап 3: Мінімізована таблиця (Редукт) ---")
    print(df_minimized)
    
    print("\n--- Етап 4: Дерево рішень (ID3) ---")
    tree = id3(df_minimized, df_minimized, df_minimized.columns[:-1].tolist(), "Zdav")
    print_tree(tree)