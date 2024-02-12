type Point = { x: number; y: number };

class Lagrange {
  private ws: number[] = [];
  private xs: number[] = [];
  private ys: number[] = [];
  private k: number = 0;

  constructor(points: Point[]) {
    if (points && points.length) {
      this.k = points.length;

      for (const { x, y } of points) {
        this.xs.push(x);
        this.ys.push(y);
      }

      for (let w, j = 0; j < this.k; j++) {
        w = 1;

        for (let i = 0; i < this.k; i++) {
          if (i !== j) w *= this.xs[j] - this.xs[i];
        }

        this.ws[j] = 1 / w;
      }
    }
  }

  public evaluate(x: number) {
    const { k, xs, ys, ws } = this;

    let a = 0;
    let b = 0;
    let c = 0;

    for (let i = 0; i < k; i++) {
      if (x === xs[i]) return ys[i];
      a = ws[i] / (x - xs[i]);
      b += a * ys[i];
      c += a;
    }

    return b / c;
  }
}

const epsilon = 0.3;

const points = [
  { x: 1.8545, y: 0.1426 },
  { x: 1.5022, y: 0.1289 },
  { x: 0.833, y: 0.0891 },
  { x: 0.5589, y: 0.0656 },
  { x: 0.3354, y: 0.0426 },
  { x: 0.1948, y: 0.026 },
];

const lagrange = new Lagrange(points);

console.log("Points:");
console.log("    x\t\t|\ty");

for (const point of points) {
  console.log(`    ${point.x}\t|\t${point.y}`);
}

console.log(`Epsilon: ${epsilon}`);

console.log(`Result: ${lagrange.evaluate(epsilon).toFixed(5)}`);
