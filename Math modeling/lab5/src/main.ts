type Point = { x: number; y: number };

class Newton {
  public n: number = 0;
  public readonly x: number[] = [];
  public readonly y: number[][] = [];

  constructor(points: Point[]) {
    for (const point of points) {
      this.x.push(point.x);
      this.y.push([point.y]);
      this.n++;
    }

    this.dividedDiffTable();
  }

  public evaluate(value: number) {
    let sum = this.y[0][0];

    for (var i = 1; i < this.n; i++) {
      sum = sum + this.proterm(i, value) * this.y[0][i];
    }

    return sum;
  }

  private dividedDiffTable() {
    for (var i = 1; i < this.n; i++) {
      for (var j = 0; j < this.n - i; j++) {
        this.y[j][i] = (this.y[j][i - 1] - this.y[j + 1][i - 1]) / (this.x[j] - this.x[i + j]);
      }
    }
  }

  private proterm(i: number, value: number) {
    let pro = 1;
    for (var j = 0; j < i; j++) {
      pro = pro * (value - this.x[j]);
    }
    return pro;
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

const newton = new Newton(points);

console.log("Points:");
console.log("    x\t\t|\ty");

for (const point of points) {
  console.log(`    ${point.x}\t|\t${point.y}`);
}

console.log(`Epsilon: ${epsilon}`);

console.log(`Result: ${newton.evaluate(epsilon).toFixed(5)}`);
