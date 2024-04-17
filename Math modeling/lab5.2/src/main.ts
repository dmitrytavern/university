import { printPoints, printDiffTable, printPolynomialFormule } from "./utils";

type Point = { x: number; y: number };

export class NewtonPolynomial {
  public n: number = 0;
  public readonly x: number[] = [];
  public readonly y: number[][] = [[]];

  constructor(points: Point[]) {
    for (const point of points) {
      this.x.push(point.x);
      this.y[0].push(point.y);
      this.n++;
    }

    for (var i = 1; i < this.n; i++) {
      this.y.push([]);

      for (var j = 0; j < this.n - i; j++) {
        this.y[i][j] = +(this.y[i - 1][j + 1] - this.y[i - 1][j]).toFixed(4);
      }
    }
  }

  public evaluate(value: number) {
    const height = this.x[1] - this.x[0];
    let sum = this.y[0][this.n - 1];
    let k = 1;

    for (let i = 1; i < this.n; i++) {
      k = k * i;

      let a = this.y[i][this.n - i - 1] / (k * Math.pow(height, i));

      for (let j = 1; j <= i; j++) {
        a *= value - this.x[this.n - j];
      }

      sum += a;
    }

    return sum;
  }
}

const epsilon = 1.2;

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

printPoints(polynomial);

console.log("");

printDiffTable(polynomial);

console.log("");

printPolynomialFormule(polynomial);

console.log("");
console.log(`Epsilon: ${epsilon}`);

console.log(`Result: ${polynomial.evaluate(epsilon).toFixed(5)}`);
