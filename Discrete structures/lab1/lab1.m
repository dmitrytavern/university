import matlab.fuzzy.*

range = 0:15;
A = 0.5*trimf(range, [2 8 13]);
B = trapmf(range, [3 5 15 15]);
C = trimf(range, [0 3 5]);
D = min(max((1 - A), B), (1 - C));

figure
plot(range, A, 'g', range, B, 'r', range, C, 'b', range, D, '--');
title('Lab1')
xlabel('Numbers')
ylabel('Membership')
legend('A', 'B', 'C', 'D')
