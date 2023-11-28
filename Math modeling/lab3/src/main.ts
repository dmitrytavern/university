const EPSILON = 0.001;

function SimpleIterationMethod(func: (x: number) => number, a: number, b: number): number {
  let x = (a + b) / 2;
  let _x0 = x;

  do {
    _x0 = x;
    x = func(_x0);
  } while (Math.abs(x - _x0) > EPSILON);

  return x;
} 

const func = (x: number) => (3 * Math.pow(x, 2) - 4 * Math.sin(x) - 1) / Math.pow(x, 2);

const a = -1;
const b = 4;

console.log("x = " + SimpleIterationMethod(func, a, b));

const funcExample1 = (x: number) => Math.pow(x, 2 / 3);

const aExample1 = 0.7;
const bExample1 = 1.1;

console.log("Example1: x = " + SimpleIterationMethod(funcExample1, aExample1, bExample1));

const funcExample2 = (x: number) => x + (Math.sin(x + Math.PI / 4) - x * x) / 2;

const aExample2 = Math.PI / 4;
const bExample2 = Math.PI / 2;

console.log("Example2: x = " + SimpleIterationMethod(funcExample2, aExample2, bExample2));
