const input = '9 9\n' +
    '010101010\n' +
    '010101010\n' +
    '101010101\n' +
    '101010101\n' +
    '000000000\n' +
    '101010101\n' +
    '101010101\n' +
    '010101010\n' +
    '010101010\n' +
    '5\n' +
    '1 1 1 3\n' +
    '4 4 4 4\n' +
    '1 1 1 1\n' +
    '5 0 0 5\n' +
    '10 1 1 1';
let LineSplitter = function (startNumber , endNumber , inputString) {
    let output = [];
    let index = 0;
    lines = inputString.split("\n");
    for (let i = startNumber; i < lines.length-endNumber; i++) {
        output[index++] = lines[i];
    }
    return output;
}
let HasZero = function (inputArray){
    for (const inputArrayElement of inputArray) {
        for (const inputArrayElementElement of inputArrayElement) {
            if (inputArrayElementElement != 0){
                return false;
            }
        }
    }
    return true;
}
let linesA = LineSplitter(0,0, input);
let x = Number(linesA[0][0]);
let y = Number(linesA[0][2]);
let timeMax = 0;
let amount = Number(linesA[y+1]);
let amounts = {};
let amountLine = LineSplitter(y+2,0, input);
for (let i = 0; i < amountLine.length; i++)
{
    let splitLine = amountLine[i].split(" ");
    amounts[i] = [Number(splitLine[0]),Number(splitLine[1]),Number(splitLine[2]),Number(splitLine[3])];
    timeMax = Number(splitLine[0]) > timeMax? Number(splitLine[0]): timeMax;
}
let loop = true;
let lineArray = LineSplitter(1,amount+1, input);
let time = 0;
while (loop || timeMax >= time){
    for (let i = 0; i < lineArray.length; i++) {
        let out="";
        for (let lineElement of lineArray[i]) {
            if (lineElement == 0){
                out += 0;
                continue;
            }
            out += Number(lineElement)-1;
        }
        lineArray[i] = String(out);
    }
    for (let i = 0; i < amount; i++) {
        if (time == amounts[i][0]){
            let amountX = amounts[i][1];
            let amountY = amounts[i][2];
            let count = amounts[i][3];
            let target = count;
            for (let j = 0; j < y; j++) {
                let lineOut="";
                let line = lineArray[j];
                for (let k = 0; k < x; k++) {
                    let box = Number(line[k]);
                    if (j == amountY && k == amountX){//nefunguje do kříže a mezi křížem a kurentní lajnou
                        box+=target;
                    }
                    else if (Math.abs(k-amountX)<target&&Math.abs(j-amountY)<target&&(0 < target-Math.abs(k-amountX)-Math.abs(j-amountY))){
                        box += target-Math.abs(k-amountX)-Math.abs(j-amountY);
                        box = box>9?9:box;
                    }
                    lineOut += Number(box);
                }
                lineArray[j] = String(lineOut);
            }
        }
    }

    for (let lineArrayElement of lineArray) {
        console.log(lineArrayElement);
    }
    console.log("\n");
    loop = !HasZero(lineArray);
    time++;
}