const alphabet: string = " АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
const alphabetLength: number = 33;
const numAlph: { [key: string]: number } = {};

for (let i = 0; i < alphabetLength; i++) {
  numAlph[alphabet[i]] = i;
}

function Encode(originalText: string, originalKey: string): string {
  const mergedText = `${originalKey}${originalText}`;
  let code = "";

  for (let i = 0; i < originalText.length; i++) {
    code += alphabet[(numAlph[originalText[i]] + numAlph[mergedText[i]]) % alphabetLength];
  }

  return code;
}

function Decode(encodedText: string, originalKey: string): string {
  let code = "";
  let decodedKey = originalKey;
  let patchIndex = 1;

  while (true) {
    const decodedKeyStartIndex = (patchIndex - 1) * originalKey.length;
    const decodedKeyEndIndex = patchIndex * originalKey.length;
    const encodedTextEndIndex =
      decodedKeyEndIndex + originalKey.length > encodedText.length
        ? encodedText.length
        : decodedKeyEndIndex + originalKey.length;

    let tempKey = "";

    for (let i = decodedKeyStartIndex; i < decodedKeyEndIndex; i++) {
      tempKey +=
        alphabet[
          (((numAlph[encodedText[i]] - numAlph[decodedKey[i % decodedKey.length]]) %
            alphabetLength) +
            alphabetLength) %
            alphabetLength
        ];
    }

    decodedKey = tempKey;

    if (patchIndex === 1) code += decodedKey;

    for (let i = decodedKeyEndIndex; i < encodedTextEndIndex; i++) {
      code +=
        alphabet[
          (((numAlph[encodedText[i]] - numAlph[decodedKey[i % decodedKey.length]]) %
            alphabetLength) +
            alphabetLength) %
            alphabetLength
        ];
    }

    if (encodedText.length === encodedTextEndIndex) break;

    patchIndex++;
  }

  return code;
}

console.log("test word:     ЄЦЙЖІЧЛВПУМЕП");
console.log("encoded word: ", Encode("ЦІЛКОМ ТАЄМНО", "КЛЮЧ"));
console.log("decoded word: ", Decode(Encode("ЦІЛКОМ ТАЄМНО", "КЛЮЧ"), "КЛЮЧ"));
