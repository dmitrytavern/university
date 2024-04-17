import type { NewtonPolynomial } from "./main";

export function printPoints(polynomial: NewtonPolynomial) {
  console.log("Points:");
  console.log("\tx       |  y");

  for (let i = 0; i < polynomial.n; i++) {
    console.log(`\t${polynomial.x[i].toFixed(4)}  |  ${polynomial.y[0][i].toFixed(4)}`);
  }
}

export function printDiffTable(polynomial: NewtonPolynomial) {
  const printArray: number[][] = [];

  for (let i = 0; i < polynomial.n; i++) {
    for (let j = 0; j < polynomial.n - i; j++) {
      if (!printArray[j]) printArray.push([]);
      printArray[j].push(polynomial.y[i][j]);
    }
  }

  console.log("Diff table:");

  for (let i = 0; i < printArray.length; i++) {
    let str = "";

    for (let j = 0; j < printArray[i].length; j++) {
      str += `\t${printArray[i][j].toFixed(4)}`;
    }

    console.log(str);
  }
}

export function printPolynomialFormule(polynomial: NewtonPolynomial) {
  const height = polynomial.x[1] - polynomial.x[0];
  let poly = `${polynomial.y[0][polynomial.n - 1].toFixed(4)}`;
  let k = 1;

  for (let i = 1; i < polynomial.n; i++) {
    k = k * i;

    const a = polynomial.y[i][polynomial.n - i - 1] / (k * Math.pow(height, i));

    poly += ` + ${a.toFixed(4)}`;

    for (let j = 1; j <= i; j++) {
      poly += `*(x - ${polynomial.x[polynomial.n - j]})`;
    }
  }

  console.log("Polynomial formule:");
  console.log(`\t${poly}`);
}
