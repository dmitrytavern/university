import matlab.fuzzy.*

% Specifying variables
input_resource_range = [0 300];
input_production_cost_range = [0 100000];
output_production_volume_range = [0 300];

% Specifying samples
sample_names = ['A', 'B', 'C', 'D'];

samples = [
    [10, 73000]
    [157, 46000]
    [257, 37000]
    [240, 90000]
];

% Creation of a fuzzy system object
fis = newfis('Production Volume');

% Definition of the input variable "Resource Quantity"
fis = addvar(fis, 'input', 'Resource Quantity', input_resource_range);
fis = addmf(fis, 'input', 1, 'Low', 'trapmf', [0 0 50 90]);
fis = addmf(fis, 'input', 1, 'Medium', 'trapmf', [50 90 200 250]);
fis = addmf(fis, 'input', 1, 'High', 'trapmf', [200 250 300 300]);

% Definition of the input variable "Cost of production"
fis = addvar(fis, 'input', 'Production Cost', input_production_cost_range);
fis = addmf(fis, 'input', 2, 'Cheap', 'trapmf', [0 0 12000 15000]);
fis = addmf(fis, 'input', 2, 'Medium', 'trapmf', [12000 15000 57000 62000]);
fis = addmf(fis, 'input', 2, 'Expensive', 'trapmf', [57000 62000 100000 100000]);

% Definition of the output variable "Production volume"
fis = addvar(fis, 'output', 'Production Volume', output_production_volume_range);
fis = addmf(fis, 'output', 1, 'Low', 'trapmf', [0 0 80 180]);
fis = addmf(fis, 'output', 1, 'Medium', 'trapmf', [80 180 230 240]);
fis = addmf(fis, 'output', 1, 'High', 'trapmf', [230 240 300 300]);

% Definition of fuzzy rules
rule1 = [1 3 1 1 1]; % If Resource Quantity = "Low"    AND Production Cost = "Expensive", THEN Production Volume = "Low"
rule2 = [1 2 1 1 1]; % If Resource Quantity = "Low"    AND Production Cost = "Medium",    THEN Production Volume = "Low"
rule3 = [1 1 2 1 1]; % If Resource Quantity = "Low"    AND Production Cost = "Cheap",     THEN Production Volume = "Medium"
rule4 = [2 3 2 1 1]; % If Resource Quantity = "Medium" AND Production Cost = "Expensive", THEN Production Volume = "Medium"
rule5 = [2 2 2 1 1]; % If Resource Quantity = "Medium" AND Production Cost = "Medium",    THEN Production Volume = "Medium"
rule6 = [2 1 3 1 1]; % If Resource Quantity = "Medium" AND Production Cost = "Cheap",     THEN Production Volume = "High"
rule7 = [3 3 2 1 1]; % If Resource Quantity = "High"   AND Production Cost = "Expensive", THEN Production Volume = "Medium"
rule8 = [3 2 3 1 1]; % If Resource Quantity = "High"   AND Production Cost = "Medium",    THEN Production Volume = "High"
rule9 = [3 1 3 1 1]; % If Resource Quantity = "High"   AND Production Cost = "Cheap",     THEN Production Volume = "High"

% Adding fuzzy rules to the system
fis = addrule(fis, [rule1; rule2; rule3; rule4; rule5; rule6; rule7; rule8; rule9]);

% Draw chart
figure;
gensurf(fis, [1 2], 1);
xlabel('Resource Quantity');
ylabel('Cost of production');
zlabel('Production volume');

% Evalfis samples
for i = 1:size(samples)
    input_res = samples(i, 1);
    input_cost = samples(i, 2);
    input_name = sample_names(i);

    hold on;
    plot3([input_res input_res], [input_cost input_cost], [0 300], ...
        'r-', 'LineWidth', 2);

    text(input_res, input_cost, 300, ...
        [input_name, ' ', num2str(round(evalfis([input_res, input_cost], fis)))], ...
        'HorizontalAlignment', 'left', ...
        'FontSize', 8);
    hold off;
end
