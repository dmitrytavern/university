import fs from "fs";
import path from "path";

type Matrix = number[][];

function printMatrix(matrix: Matrix) {
  for (const row of matrix) {
    console.log("\t" + row.join("\t"));
  }
}

function parseFile(path: string): Matrix {
  try {
    return fs
      .readFileSync(path, { encoding: "utf-8" })
      .split("\n")
      .map((line) => line.split(" ").map((number) => Number(number)));
  } catch (error: any) {
    throw new Error(error);
  }
}

function optimizeMatrix(matrix: Matrix) {
  const n = matrix.length;

  for (let iteration = 0; iteration < n; iteration++) {
    const row = matrix[iteration];
    const element = row[iteration];

    for (let j = iteration; j <= n; j++) {
      row[j] /= element;
    }

    for (let i = 0; i < n; i++) {
      if (i !== iteration) {
        const k = matrix[i][iteration] / row[iteration];
        for (let j = iteration; j <= n; j++) {
          matrix[i][j] = matrix[i][j] - k * row[j];
        }
      }
    }
  }
}

function getMatrixRoots(matrix: Matrix): number[] {
  const roots = [];
  const n = matrix.length;

  for (let iteration = 0; iteration < n; iteration++) {
    roots.push(matrix[iteration][n]);
  }

  return roots;
}

function main() {
  const filepath = path.join(__dirname, "system.txt");

  console.log("Loading matrix form file: ./src/system.txt");

  const matrix = parseFile(filepath);

  console.log("\nMatrix loaded:");

  printMatrix(matrix);

  optimizeMatrix(matrix);

  console.log("\nMatrix optimized:");

  printMatrix(matrix);

  const matrixRoots = getMatrixRoots(matrix);

  console.log("\nMatrix roots:", matrixRoots);
}

main();
