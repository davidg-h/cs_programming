
/* We're keeping the old stuff */
function createRegistrationForm() {
  let main = document.getElementsByTagName("main")[0];
  let f  = document.createElement("FORM");
  let label = document.createElement("LABEL");
  let input = document.createElement("input");
  label.textContent = "Benutzername";
  input.setAttribute("name", "benutzername");
  input.setAttribute("placeholder", "Benutzername");
  f.appendChild(label);
  f.appendChild(input);
  label = document.createElement("LABEL");
  input = document.createElement("input");
  label.textContent = "eMail Adresse";
  input.setAttribute("name", "mail");
  input.setAttribute("placeholder", "eMail-Adresse");
  input.setAttribute("type", "email");
  f.appendChild(label);
  f.appendChild(input);
  label = document.createElement("LABEL");
  input = document.createElement("input");
  label.textContent = "Passwort";
  input.setAttribute("name", "password");
  input.setAttribute("placeholder", "Passwort");
  input.setAttribute("type", "password");
  f.appendChild(label);
  f.appendChild(input);
  input = document.createElement("button");
  input.setAttribute("type", "submit");
  input.textContent =  "Jetzt registrieren!";
  f.appendChild(input);
  f.id = "toymodels-form";
  f.setAttribute("action", "http://localhost/toymodels/index.php/register");
  main.replaceChildren(f);
}

function onError(error) {
  alert("Error fetching data: " + error);
};

/* 'Generic' table creation, this wants to be an object, I assume... */ 
function createTableData(content, tableData = "td") {
  let td = document.createElement(tableData);
  /* Note: this is potentially a security risk so we try to avoid it. */
  if (content.startsWith("<button")) {
    td.innerHTML = content;
  } else {
    td.textContent = content;
  }
  return td;
}

function createTr(contents) {
  let tr = document.createElement("tr");
  contents.forEach((elem) => {
    tr.appendChild(createTableData(elem));
  });
  return tr;
}

function createTable(data) {
  let table = document.createElement("table");
  let thead = document.createElement("thead");
  data.head.forEach((elem) => {
    thead.appendChild(createTableData(elem, "th"));
  });
  table.appendChild(thead);

  data.content.forEach( (contents) => {
    let tr = createTr(contents);
    table.appendChild(tr);
  });

  return table;
}

/* This updates the cart button */
function updateCartBtn(nItems) {
  let btn = document.querySelector("#usersection button:first-child");
  if (nItems > 0) {
    let textNode = document.createTextNode(`(${nItems})`);
    if (btn.lastChild.nodeType === 3 && btn.lastChild.nodeValue.startsWith("(")) {
       btn.removeChild(btn.lastChild); 
    }
    btn.appendChild(textNode);
  } else {
    if (btn.lastChild.nodeType === 3 && btn.lastChild.nodeValue.startsWith("(")) {
       btn.removeChild(btn.lastChild); 
    }
  }
}

function addToCart(event) {
  let requestUrl = new URL("http://localhost/tms/tms/toymodels_service.php");
  requestUrl.searchParams.append("method", "addToCart");
  requestUrl.searchParams.append("artNo", event.currentTarget.value);
  
  fetch(requestUrl, { "credentials": "same-origin" })
  .then( (result) => {
    if (result.ok && result.headers.get("Content-Type") === "application/json") {
      return result.json();
    } else {
      throw "Invalid result or data type!";
    }
  })
  .then( (dataObject) => {
    updateCartBtn(dataObject.data.nCartItems);
  })
  .catch(onError);
}

function mainPage() {
  let headerHtml = `<section id="productsection">
        <h1>Willkommen im Toy-Models Online-Shop</h1>
        <h4>Viel Spass bei Ihrem Einkauf!</h4>
        </section>`;
  
  let main = document.getElementsByTagName("MAIN")[0];

  main.innerHTML = headerHtml;
  let section = document.getElementById("productsection");

  // Fetch Table
  fetch("http://localhost/tms/tms/toymodels_service.php", { "credentials": "same-origin" })
  .then( (result) => {
    if (result.ok && result.headers.get("Content-Type") === "application/json") {
      return result.json();
    } else {
      throw "Invalid result or data type!";
    }
  })
  .then( (dataObject) => {
    let data = dataObject.data;
    data.content.forEach((elem) => {
      return elem.push(`<button onclick='addToCart(event);' value='${elem[0]}'>In den Warenkorb!</button>`);
    });
    let table = createTable(data);
    section.appendChild(table);
    updateCartBtn(dataObject.data.nCartItems);
  })
  .catch(onError);
}

function cartPage() {
  alert("Heres the cart!");
  /* Leaving open for the exercise */
  /* The searchbar is also open */
}

function setupPage() {
  document.querySelector("#usersection button:first-child").onclick = cartPage;
  document.forms[0].onsubmit = (event) => {
    event.preventDefault();
    event.stopPropagation();
    alert("Implement me!");
  }
  document.forms[1].onsubmit = (event) => {
    event.preventDefault();
    event.stopPropagation();
    alert("Implement me!");
  }
  mainPage();
}

document.body.onload = setupPage;