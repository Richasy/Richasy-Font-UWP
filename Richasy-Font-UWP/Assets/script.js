let nodes = document.querySelectorAll('.glyphName');
var theNames = [];
for (var value of nodes.values()) {
    theNames.push(value.value);
}
let yo = '';
for (var n of theNames) {
    yo += n + '\n';
}
console.log(yo);