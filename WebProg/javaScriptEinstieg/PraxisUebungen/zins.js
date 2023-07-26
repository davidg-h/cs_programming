function setUpInput() {
  const body = document.querySelector("body");

  let label = document.createElement("label");
  let input = document.createElement("input");
  input.setAttribute("id", "jahre");
  input.setAttribute("type", "number");
  input.setAttribute("min", "1");
  label.innerHTML = "Jahre";

  body.appendChild(label);
  body.appendChild(input);
  body.appendChild(document.createElement("br"));

  label = document.createElement("label");
  input = document.createElement("input");
  input.setAttribute("id", "kapital");
  input.setAttribute("type", "number");
  input.setAttribute("min", "0");
  label.innerHTML = "Kapital";

  body.appendChild(label);
  body.appendChild(input);
  body.appendChild(document.createElement("br"));

  label = document.createElement("label");
  input = document.createElement("input");
  input.setAttribute("id", "zinssatz");
  input.setAttribute("type", "number");
  input.setAttribute("min", "0");
  input.setAttribute("max", "1");
  input.setAttribute("step", "0.01");
  label.innerHTML = "Zinssatz pro Jahr";

  body.appendChild(label);
  body.appendChild(input);

  const button = document.createElement("button");
  button.innerHTML = "Berechnen";

  body.appendChild(document.createElement("br"));
  body.appendChild(button);

  label = document.createElement("label");
  input = document.createElement("input");
  input.setAttribute("id", "ohneZinsesZins");
  input.setAttribute("type", "checkbox");
  label.innerHTML = "ohne Zinses Zins";
  label.setAttribute("for", "ohneZinsesZins");
  body.appendChild(document.createElement("br"));
  body.appendChild(input);
  body.appendChild(label);

  label = document.createElement("label");
  input = document.createElement("input");
  input.setAttribute("id", "mitZinsesZins");
  input.setAttribute("type", "checkbox");
  label.innerHTML = "mit Zinses Zins";
  label.setAttribute("for", "mitZinsesZins");
  body.appendChild(input);
  body.appendChild(label);

  button.addEventListener("click", () => {
    if (document.getElementById("ohneZinsesZins").checked) {
      alert("Zins: " + calculateZins());
    } else if (document.getElementById("mitZinsesZins").checked) {
      alert("Zinses Zins: " + calculateZinsesZins());
    } else {
      alert("Bitte wähle eine Zins Möglichkeit aus");
    }
  });
}

function calculateZins() {
  const kapital = document.getElementById("kapital").value;
  const jahre = document.getElementById("jahre").value;
  const zinssatz = document.getElementById("zinssatz").value;

  console.log(kapital);
  console.log(jahre);
  console.log(zinssatz);

  return kapital * zinssatz * jahre;
}

function calculateZinsesZins() {
  let kapital = document.getElementById("kapital").value;
  let jahre = document.getElementById("jahre").value;
  let zinssatz = document.getElementById("zinssatz").value;

  let zins = 0;

  for (let index = 0; index < jahre; index++) {
    zins += kapital * zinssatz;
    kapital = Number(kapital) + zins;
  }

  return zins;
}

function bmiSetUp() {
  const body = document.querySelector("body");

  let label = document.createElement("label");
  let input = document.createElement("input");
  input.setAttribute("id", "gewicht");
  input.setAttribute("type", "number");
  input.setAttribute("min", "0");
  label.setAttribute("for", "gewicht");
  label.innerHTML = "Gewicht";

  body.appendChild(input);
  body.appendChild(label);

  label = document.createElement("label");
  input = document.createElement("input");
  input.setAttribute("id", "höhe");
  input.setAttribute("type", "number");
  input.setAttribute("min", "0");
  label.setAttribute("for", "höhe");
  label.innerHTML = "Größe";

  body.appendChild(input);
  body.appendChild(label);
  let button = document.createElement("button");
  button.innerHTML = "BMI";
  button.setAttribute("onclick", "bmiCalc()");
  body.appendChild(button);
}

function bmiCalc() {
  let g = document.getElementById("gewicht").value;
  let h = document.getElementById("höhe").value / 100;

  let bmi = g / (h * h);

  let p;

  if (18.5 <= bmi < 25) {
    p = document.createElement("p");
    p.innerHTML = "BMI = normal " + bmi;
    document.querySelector("body").appendChild(p);
  } else if (25 <= bmi < 30) {
    p = document.createElement("p");
    p.innerHTML = "BMI = Übergewicht" + bmi;
    document.querySelector("body").appendChild(p);
  } else if (30 <= bmi < 35) {
    p = document.createElement("p");
    p.innerHTML = "BMI = Adipositas Grad I" + bmi;
    document.querySelector("body").appendChild(p);
    alert("Gehe zum Artz");
  }
}
