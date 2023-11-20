let EPSILON = 0.0001;

function bisectionMethod(func: (x: number) => number, a: number, b: number): number | null {
  if (func(a) * func(b) >= 0) {
    console.log("You have not assumed" + " right a and b");
    return null;
  }

  let c = a;

  while (b - a >= EPSILON) {
    // Find middle point
    c = (a + b) / 2;

    // Check if middle point is root
    if (func(c) == 0.0) break;

    // Decide the side to repeat the steps
    if (func(c) * func(a) < 0)
    {
      b = c
    }
    else
    {
      a = c
    }
  }

  return c;
}

// Task

const func = (x: number) => x * x * x - 3 * x * x + 4 * Math.sin(x) + 1;
const rangeFrom = -5;
const rangeTo = 5;

const result = bisectionMethod(func, rangeFrom, rangeTo);

if (result !== null)
{
  console.log(`Корень функции: ${result}`);
}
else
{
  console.log("Метод не смог найти корень.");
}
