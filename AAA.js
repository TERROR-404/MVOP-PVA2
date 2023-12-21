const input = `ANNA
NNNA
NANN
NNNN
4 0.3
1 0.2
2 0.6
2 0.9`;
let array = new Array();
let i = 0;
let size = 1;
let xSum=0;
let ySum=0;
let zSum=0;
let lines = input.split("\n");
for (const y in lines) {
    for (const x in lines[y]) {
        if (x>size){
            size++;
        }
        if (lines[y][x]=="A") {
            array[i++] = String(x)+","+String(y);
            ySum+= Number(y);
            xSum+= Number(x);
        }
    }
    if (y==size-1) {//pomáhá ke snížení počtu zbytečných iterací, ale jinak je redundantní
        break;
    }
}
for (let j = size; j < size+array.length; j++) {
    array[j-size] += ","+String(lines[j+1].replace("\r","").split(" ")[0])+","+String(lines[j+1].replace("\r","").split(" ")[1]);
    zSum+= Number(lines[j+1].replace("\r","").split(" ")[0]);
}
const averageX = Math.floor(xSum/size);
const averageY = Math.floor(ySum/size);
const averageZ = Math.floor(zSum/size);
const averagePosition = String(averageX)+","+String(averageY)+","+String(averageZ);
const half = Math.round(size/2);
let score = 0;
for (const iterator of array) {
    let coordinates = iterator.split(",");
    if (Math.abs(Math.abs(averageX-coordinates[0])+Math.abs(averageY-coordinates[1])+Math.abs(averageZ-coordinates[2]))==half) {
        let d = Math.floor(Math.sqrt(Math.pow(averageX-Number(coordinates[0]),2)+Math.pow(averageY-Number(coordinates[1]),2)+Math.pow(averageZ-Number(coordinates[2]),2)));
        let negPropability = Number((1-Number(coordinates[3])).toFixed(2))
        score+=Number((d*negPropability).toFixed(2));
    }
}
console.log(score);
