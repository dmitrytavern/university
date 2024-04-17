const Algebrite = require("algebrite");

import { NewtonPolynomial } from "./NewtonPolynomial";
import { generatePolynomialFormule, printDiffTable, printPoints } from "./utils";

const epsilon = 1.16;

const points = [
  { x: 1, y: 1.0 },
  { x: 1.13, y: 1.025 },
  { x: 1.26, y: 1.1013 },
  { x: 1.39, y: 1.2371 },
  { x: 1.52, y: 1.4502 },
  { x: 1.62, y: 1.7713 },
  { x: 1.78, y: 2.252 },
];

const polynomial = new NewtonPolynomial(points);

const poly = generatePolynomialFormule(polynomial);
const poly_result = Algebrite.run(poly.replace(/x/g, epsilon.toString())).replace(/\.\.\./g, "");

const poly_1 = Algebrite.run(`d(${poly})`).replace(/\.\.\./g, "");
const poly_1_result = Algebrite.run(poly_1.replace(/x/g, epsilon.toString())).replace(
  /\.\.\./g,
  ""
);

const poly_2 = Algebrite.run(`d(${poly_1})`).replace(/\.\.\./g, "");
const poly_2_result = Algebrite.run(poly_2.replace(/x/g, epsilon.toString())).replace(
  /\.\.\./g,
  ""
);

printPoints(polynomial);

console.log("");

printDiffTable(polynomial);

console.log("");

console.log("");
console.log(`Epsilon: ${epsilon}`);

console.log("Polynomial formule:");
console.log(`\t${poly}`);
console.log(`\tx = ${epsilon}; ${poly_result};`);

console.log("");

console.log("Polynomial formule 2:");
console.log(`\t${poly_1}`);
console.log(`\tx = ${epsilon}; ${poly_1_result};`);

console.log("");

console.log("Polynomial formule 3:");
console.log(`\t${poly_2}`);
console.log(`\tx = ${epsilon}; ${poly_2_result};`);
