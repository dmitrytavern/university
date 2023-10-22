import fs from "fs";
import path from "path";

function readFile(path: string): string {
  try {
    return fs.readFileSync(path, { encoding: "utf-8" });
  } catch (error: any) {
    throw new Error(error);
  }
}

function stringToBinary(string: string): string[] {
  try {
    return Array.from(Buffer.from(string, "utf-8")).map((number) => number.toString(2));
  } catch (error: any) {
    throw new Error(error);
  }
}

function binaryToString(string: string) {
  try {
    return String.fromCharCode(parseInt(string, 2));
  } catch (error: any) {
    throw new Error(error);
  }
}

function makeErrorInCode(string: string): string {
  const arr = string.split("");
  arr[0] = arr[0] === "0" ? "1" : "0";
  return arr.join("");
}

function encodeBinaryByHamming(string: string) {
  let output = string;
  let controlBitsIndexes = [];
  let l = string.length;
  let i = 1;
  let key, j, arr, temp, check;

  while (l / i >= 1) {
    controlBitsIndexes.push(i);
    i *= 2;
  }

  for (j = 0; j < controlBitsIndexes.length; j++) {
    key = controlBitsIndexes[j];
    arr = output.slice(key - 1).split("");
    temp = chunk(arr, key);
    check =
      temp
        .reduce(function (prev, next, index) {
          if (!(index % 2)) {
            prev = prev.concat(next);
          }
          return prev;
        }, [])
        .reduce(function (prev, next) {
          return +prev + +next;
        }, 0) % 2
        ? 1
        : 0;
    output = output.slice(0, key - 1) + check + output.slice(key - 1);
    if (j + 1 === controlBitsIndexes.length && output.length / (key * 2) >= 1) {
      controlBitsIndexes.push(key * 2);
    }
  }

  return output;
}

function pureDecodeByHamming(string: string) {
  var controlBitsIndexes = [];
  var l = string.length;
  var originCode = string;
  var i;

  i = 1;
  while (l / i >= 1) {
    controlBitsIndexes.push(i);
    i *= 2;
  }

  controlBitsIndexes.forEach(function (key, index) {
    originCode = originCode.substring(0, key - 1 - index) + originCode.substring(key - index);
  });

  return originCode;
}

function decodeByHamming(string: string) {
  var controlBitsIndexes = [];
  var sum = 0;
  var l = string.length;
  var i = 1;
  var output = pureDecodeByHamming(string);
  var inputFixed = encodeBinaryByHamming(output);

  while (l / i >= 1) {
    controlBitsIndexes.push(i);
    i *= 2;
  }

  controlBitsIndexes.forEach(function (i) {
    if (string[i] !== inputFixed[i]) {
      sum += i;
    }
  });

  if (sum) {
    output[sum - 1] === "1"
      ? (output = replaceCharacterAt(output, sum - 1, "0"))
      : (output = replaceCharacterAt(output, sum - 1, "1"));
  }
  return output;
}

function checkByHamming(string: string) {
  var inputFixed = encodeBinaryByHamming(pureDecodeByHamming(string));
  return !(inputFixed === string);
}

function replaceCharacterAt(str: string, index: number, character: string) {
  return str.substr(0, index) + character + str.substr(index + character.length);
}

function chunk(arr: string[], size: number) {
  var chunks = [],
    i = 0,
    n = arr.length;
  while (i < n) {
    chunks.push(arr.slice(i, (i += size)));
  }
  return chunks;
}

function main() {
  const filepath = path.join(__dirname, "name.txt");

  console.log("Loading name form file: ./src/name.txt");

  const filecontent = readFile(filepath);

  console.log(`\nLoaded name:                       ${filecontent}`);

  const filebinary = stringToBinary(filecontent);

  console.log(`\nBinary name:                       ${filebinary}`);

  const fileencoded = filebinary.map((x) => encodeBinaryByHamming(x));

  console.log(`\nBinary name (encoded):             ${fileencoded}`);

  const filebinarywitherror = fileencoded.map((x, i) => (i % 2 == 0 ? makeErrorInCode(x) : x));

  console.log(`\nBinary name (encoded with error):  ${filebinarywitherror}`);

  const filehaserror = filebinarywitherror.map((x) => checkByHamming(x));

  console.log(`\nBinary name has error:             ${filehaserror}`);

  const filedecoded = fileencoded.map((x) => decodeByHamming(x));

  console.log(`\nBinary name (decoded with fixing): ${filedecoded}`);

  const filenormaldecoded = filedecoded.map((x) => binaryToString(x));

  console.log(`\nName (decoded with fixing):        ${filenormaldecoded}`);

  const filenormal = filenormaldecoded.join("");

  console.log(`\nName:                              ${filenormal}`);
}

main();
