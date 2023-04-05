import matlab.fuzzy.*

% Specifying variables
financial_value_range = [0 100];
strategic_value_range = [0 100];
priority_level = [0 1];
risk_level = [0 1];

% Specifying samples
sample_names = ['A', 'B', 'C', 'D'];
samples = [
    [100, 100, 0]
    [86, 21, 0.1]
    [12, 56, 0.4]
    [38, 44, 0.7]
];

% Creation of a fuzzy system object
fis = newfis('Project Management');

% Definition of the input variable "Financial value"
fis = addvar(fis, 'input', 'Financial value', financial_value_range);
fis = addmf(fis, 'input', 1, 'Low',          'trapmf', [0 0 15 35]);
fis = addmf(fis, 'input', 1, 'Medium',       'trimf',  [25 40 65]);
fis = addmf(fis, 'input', 1, 'Upper medium', 'trimf',  [55 65 75]);
fis = addmf(fis, 'input', 1, 'High',         'trapmf', [70 80 100 100]);

% Definition of the input variable "Strategic value"
fis = addvar(fis, 'input', 'Strategic value', strategic_value_range);
fis = addmf(fis, 'input', 2, 'Low',          'trapmf', [0 0 15 35]);
fis = addmf(fis, 'input', 2, 'Medium',       'trimf',  [25 40 65]);
fis = addmf(fis, 'input', 2, 'Upper medium', 'trimf',  [55 65 75]);
fis = addmf(fis, 'input', 2, 'High',         'trapmf', [70 80 100 100]);

% Definition of the input variable "Risk level"
fis = addvar(fis, 'input', 'Risk level', risk_level);
fis = addmf(fis, 'input', 3, 'Low',          'trapmf', [0 0 0.15 0.35]);
fis = addmf(fis, 'input', 3, 'Medium',       'trimf',  [0.25 0.4 0.65]);
fis = addmf(fis, 'input', 3, 'Upper medium', 'trimf',  [0.55 0.65 0.75]);
fis = addmf(fis, 'input', 3, 'High',         'trapmf', [0.7 0.8 1 1]);

% Definition of the output variable "Priority level"
fis = addvar(fis, 'output', 'Priority level', priority_level);
fis = addmf(fis, 'output', 1, 'Very Low',     'trapmf', [0 0 0.1 0.2]);
fis = addmf(fis, 'output', 1, 'Low',          'trimf',  [0.15 0.25 0.35]);
fis = addmf(fis, 'output', 1, 'Medium',       'trimf',  [0.3 0.4 0.5]);
fis = addmf(fis, 'output', 1, 'Upper medium', 'trimf',  [0.45 0.55 0.65]);
fis = addmf(fis, 'output', 1, 'High',         'trimf',  [0.6 0.7 0.8]);
fis = addmf(fis, 'output', 1, 'Very High',    'trapmf', [0.75 0.85 1 1]);

% Adding fuzzy rules to the system
fis = addrule(fis, [
    [4 4 1 6 1 1]; % If Financial value = "High"         AND Strategic value = "High",         AND Risk level = "Low",          THEN Priority level = "Very High"
    [4 4 2 5 1 1]; % If Financial value = "High"         AND Strategic value = "High",         AND Risk level = "Medium",       THEN Priority level = "High"
    [4 4 3 4 1 1]; % If Financial value = "High"         AND Strategic value = "High",         AND Risk level = "Upper medium", THEN Priority level = "Upper medium"
    [4 4 4 3 1 1]; % If Financial value = "High"         AND Strategic value = "High",         AND Risk level = "High",         THEN Priority level = "Medium"

    [4 3 1 5 1 1]; % If Financial value = "High"         AND Strategic value = "Upper medium", AND Risk level = "Low",          THEN Priority level = "High"
    [4 3 2 5 1 1]; % If Financial value = "High"         AND Strategic value = "Upper medium", AND Risk level = "Medium",       THEN Priority level = "High"
    [4 3 3 3 1 1]; % If Financial value = "High"         AND Strategic value = "Upper medium", AND Risk level = "Upper medium", THEN Priority level = "Medium"
    [4 3 4 3 1 1]; % If Financial value = "High"         AND Strategic value = "Upper medium", AND Risk level = "High",         THEN Priority level = "Medium"

    [4 2 1 5 1 1]; % If Financial value = "High"         AND Strategic value = "Medium",       AND Risk level = "Low",          THEN Priority level = "High"
    [4 2 2 4 1 1]; % If Financial value = "High"         AND Strategic value = "Medium",       AND Risk level = "Medium",       THEN Priority level = "Upper medium"
    [4 2 3 3 1 1]; % If Financial value = "High"         AND Strategic value = "Medium",       AND Risk level = "Upper medium", THEN Priority level = "Medium"
    [4 2 4 3 1 1]; % If Financial value = "High"         AND Strategic value = "Medium",       AND Risk level = "High",         THEN Priority level = "Medium"

    [4 1 1 4 1 1]; % If Financial value = "High"         AND Strategic value = "Low",          AND Risk level = "Low",          THEN Priority level = "Upper medium"
    [4 1 2 4 1 1]; % If Financial value = "High"         AND Strategic value = "Low",          AND Risk level = "Medium",       THEN Priority level = "Upper medium"
    [4 1 3 2 1 1]; % If Financial value = "High"         AND Strategic value = "Low",          AND Risk level = "Upper medium", THEN Priority level = "Low"
    [4 1 4 2 1 1]; % If Financial value = "High"         AND Strategic value = "Low",          AND Risk level = "High",         THEN Priority level = "Low"

    [3 3 1 4 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Upper medium", AND Risk level = "Low",          THEN Priority level = "Upper medium"
    [3 3 2 4 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Upper medium", AND Risk level = "Medium",       THEN Priority level = "Upper medium"
    [3 3 3 3 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Upper medium", AND Risk level = "Upper medium", THEN Priority level = "Medium"
    [3 3 4 2 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Upper medium", AND Risk level = "High",         THEN Priority level = "Low"

    [3 2 1 4 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Medium",       AND Risk level = "Low",          THEN Priority level = "Upper medium"
    [3 2 2 4 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Medium",       AND Risk level = "Medium",       THEN Priority level = "Upper medium"
    [3 2 3 3 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Medium",       AND Risk level = "Upper medium", THEN Priority level = "Medium"
    [3 2 4 2 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Medium",       AND Risk level = "High",         THEN Priority level = "Low"

    [3 1 1 3 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Low",          AND Risk level = "Low",          THEN Priority level = "Medium"
    [3 1 2 3 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Low",          AND Risk level = "Medium",       THEN Priority level = "Medium"
    [3 1 3 2 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Low",          AND Risk level = "Upper medium", THEN Priority level = "Low"
    [3 1 4 2 1 1]; % If Financial value = "Upper medium" AND Strategic value = "Low",          AND Risk level = "High",         THEN Priority level = "Low"

    [2 2 1 3 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Low",          THEN Priority level = "Medium"
    [2 2 2 3 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Medium",       THEN Priority level = "Medium"
    [2 2 3 2 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Upper medium", THEN Priority level = "Low"
    [2 2 4 2 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "High",         THEN Priority level = "Low"

    [2 1 1 3 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Low",          THEN Priority level = "Medium"
    [2 1 2 3 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Medium",       THEN Priority level = "Medium"
    [2 1 3 2 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Upper medium", THEN Priority level = "Low"
    [2 1 4 1 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "High",         THEN Priority level = "Very Low"

    [1 1 1 2 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Low",          THEN Priority level = "Low"
    [1 1 2 2 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Medium",       THEN Priority level = "Low"
    [1 1 3 1 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "Upper medium", THEN Priority level = "Very Low"
    [1 1 4 1 1 1]; % If Financial value = "Medium"       AND Strategic value = "Medium",       AND Risk level = "High",         THEN Priority level = "Very Low"
]);

% Draw chart
figure;
% plotfis(fis);
gensurf(fis, [2 1], 1);
xlabel('Strategic value');
ylabel('Financial value');
zlabel('Priority level');

% Evalfis samples
for i = 1:size(samples)
    input_fin = samples(i, 1);
    input_strat = samples(i, 2);
    input_risk = samples(i, 3);
    input_name = sample_names(i);

    hold on;
    plot3([input_strat input_strat], [input_fin input_fin], [0 1], ...
        'r-', 'LineWidth', 2);

    text(input_strat, input_fin, 0.73, ...
        [input_name, ' ', num2str(round(evalfis([input_fin, input_strat, input_risk], fis), 2, 'significant'))], ...
        'HorizontalAlignment', 'left', ...
        'FontSize', 8);
    hold off;
end
