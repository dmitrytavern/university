import numpy as np
from scipy.stats import norm

pos_years = np.array([10, 12, 5, 15, 8, 3])
pos_loan = np.array([100, 5, 30, 400, 100, 2])
prob_apt_pos = 2 / 6
prior_pos = 6 / 10

neg_years = np.array([1, 14, 2, 20])
neg_loan = np.array([250, 300, 100, 100])
prob_apt_neg = 2 / 4
prior_neg = 4 / 10

target_years = 20
target_loan = 120

def gaussian_prob(value, data):
    mu = np.mean(data)
    sigma = np.std(data, ddof=1) # ddof=1 для вибіркової дисперсії
    return norm.pdf(value, mu, sigma)

p_years_pos = gaussian_prob(target_years, pos_years)
p_loan_pos = gaussian_prob(target_loan, pos_loan)

score_pos = prior_pos * prob_apt_pos * p_years_pos * p_loan_pos

p_years_neg = gaussian_prob(target_years, neg_years)
p_loan_neg = gaussian_prob(target_loan, neg_loan)

score_neg = prior_neg * prob_apt_neg * p_years_neg * p_loan_neg

print(f"Ймовірність Positive score: {score_pos:.8f}")
print(f"Ймовірність Negative score: {score_neg:.8f}")

if score_pos > score_neg:
    print("\nПРОГНОЗ: Позитивний (Кредит схвалено)")
else:
    print("\nПРОГНОЗ: Негативний (Кредит відхилено)")