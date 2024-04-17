export type Point = { x: number; y: number };

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
}
