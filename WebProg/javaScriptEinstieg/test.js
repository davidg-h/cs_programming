// alert("Hallo Welt")

"use strict";
let input = prompt("Please enter your name", "");
if (input) {
  // alert(`Hello ${input}`);
  // output in html file
  document.write(`<h1>Hello ${input}</h1>`);
} else {
  document.write(`<h1>Hello Visitor</h1>`);
}

confirm("Ready?");
document.write("Count down:");

for (let i = 10; i >= 0; i--) {
  document.write(`<p>${i}</p>`);
  console.log(i);
}
console.log(input);

let eingabe, ergebnis, text;

function wurzelZiehen(zahl) {
  // Hilfsfunktion, die Wurzel aus übergebener 'zahl' zieht und als 'ergebnis' zurückgibt
  zahl = parseFloat(zahl);
  ergebnis = Math.sqrt(zahl);
  return ergebnis;
}

eingabe = prompt("Bitte geben Sie eine Zahl ein!", eingabe);

wurzelZiehen(eingabe);
text = `Die Wurzel von ${eingabe} ist ${ergebnis}.`;
console.log(text);

// Objekt dynamisch erstellt; object log in console
let data = new Object();

data.id = "17283";
data.firstName = "Hans";
data.name = "Meier";
data.type = "Bestellung";
data.items = [2231, 188832, 231231, 3123, 123];
console.log(data);
