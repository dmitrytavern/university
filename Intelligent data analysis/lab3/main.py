import numpy as np
import matplotlib.pyplot as plt
import random

class AntColonyOptimizer:
    def __init__(self, num_cities, num_ants, alpha=1.0, beta=2.0, evaporation_rate=0.1, Q=1.0):
        """
        Ініціалізація параметрів алгоритму[cite: 114].
        """
        self.num_cities = num_cities
        self.num_ants = num_ants
        self.alpha = alpha 
        self.beta = beta
        self.evaporation_rate = evaporation_rate 
        self.Q = Q
        
        self.cities = np.random.rand(num_cities, 2)
        
        self.distances = self._calculate_distance_matrix()
        self.pheromones = np.ones((num_cities, num_cities)) 

        self.best_route = None
        self.best_distance = float('inf')

    def _calculate_distance_matrix(self):
        """Обчислює Евклідову відстань між усіма парами міст[cite: 228]."""
        dist_matrix = np.zeros((self.num_cities, self.num_cities))
        for i in range(self.num_cities):
            for j in range(self.num_cities):
                if i != j:
                    # dist = sqrt((x1-x2)^2 + (y1-y2)^2)
                    dist_matrix[i][j] = np.linalg.norm(self.cities[i] - self.cities[j])
                else:
                    dist_matrix[i][j] = np.inf # Щоб мураха не залишалася на місці
        return dist_matrix

    def _select_next_city(self, current_city, visited):
        """
        Вибір наступного міста (імітація «Рулетки»)[cite: 303].
        Ймовірність залежить від феромону (tau) та оберненої відстані (eta).
        """
        probabilities = []
        possible_cities = []

        for city_idx in range(self.num_cities):
            if city_idx not in visited:
                tau = self.pheromones[current_city][city_idx] ** self.alpha
                eta = (1.0 / self.distances[current_city][city_idx]) ** self.beta
                probabilities.append(tau * eta)
                possible_cities.append(city_idx)

        probabilities = np.array(probabilities)
        probabilities = probabilities / probabilities.sum()

        next_city = np.random.choice(possible_cities, p=probabilities)
        return next_city

    def _run_single_ant(self):
        """Моделювання проходу однієї мурахи (побудова маршруту Tk)[cite: 126]."""
        start_city = random.randint(0, self.num_cities - 1)
        path = [start_city]
        visited = {start_city}
        current_city = start_city
        path_length = 0

        for _ in range(self.num_cities - 1):
            next_city = self._select_next_city(current_city, visited)
            path_length += self.distances[current_city][next_city]
            path.append(next_city)
            visited.add(next_city)
            current_city = next_city

        path_length += self.distances[current_city][start_city]
        path.append(start_city)

        return path, path_length

    def update_pheromones(self, all_paths):
        """
        Оновлення слідів феромонів[cite: 135].
        1. Випаровування.
        2. Додавання нових слідів.
        """
        self.pheromones *= (1 - self.evaporation_rate)

        for path, length in all_paths:
            for i in range(len(path) - 1):
                u, v = path[i], path[i+1]
                self.pheromones[u][v] += self.Q / length
                self.pheromones[v][u] += self.Q / length

    def solve(self, iterations=50):
        """Основний цикл алгоритму[cite: 121]."""
        print(f"Запуск алгоритму для {self.num_cities} міст...")
        
        for t in range(iterations):
            all_paths = []
            
            for k in range(self.num_ants):
                path, length = self._run_single_ant()
                all_paths.append((path, length))

                if length < self.best_distance:
                    self.best_distance = length
                    self.best_route = path
            
            self.update_pheromones(all_paths)
            
            if (t + 1) % 10 == 0:
                print(f"Ітерація {t+1}: Найкраща довжина = {self.best_distance:.4f}")

        print(f"\nОптимальний маршрут знайдено (T*). Довжина (L*): {self.best_distance:.4f}")
        return self.best_route, self.best_distance

    def plot_solution(self):
        """Візуалізація результату."""
        x = self.cities[:, 0]
        y = self.cities[:, 1]

        plt.figure(figsize=(8, 6))
        plt.scatter(x, y, c='red', marker='o', s=50, label='Міста')
        
        for i, txt in enumerate(range(self.num_cities)):
            plt.annotate(txt, (x[i], y[i]), xytext=(5, 5), textcoords='offset points')

        if self.best_route:
            route_x = [self.cities[i][0] for i in self.best_route]
            route_y = [self.cities[i][1] for i in self.best_route]
            plt.plot(route_x, route_y, c='blue', linestyle='-', linewidth=1, label='Маршрут')
            
            plt.plot(route_x[0], route_y[0], 'g*', markersize=15, label='Старт/Фініш')

        plt.title(f"Рішення задачі комівояжера (ACO)\nМіст: {self.num_cities}, Довжина шляху: {self.best_distance:.2f}")
        plt.legend()
        plt.grid(True)
        plt.savefig('my_image_plot.png')

if __name__ == "__main__":
    num_cities_random = random.randint(3, 100)

    optimizer = AntColonyOptimizer(
        num_cities=num_cities_random, 
        num_ants=20,     # Кількість мурах (m)
        alpha=1.0,       # Важливість феромону
        beta=2.0,        # Важливість відстані
        evaporation_rate=0.1, # Коефіцієнт випаровування (1 - 0.9 з коду C#)
        Q=1.0            # Константа Q
    )
    
    optimizer.solve(iterations=50)
    optimizer.plot_solution()