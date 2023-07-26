function init() {
  createTable();
  setInterval(function () {
    bingoWinLogic();
  }, 2000);
}

//only win logic for full rows, colums and diagonals will be added later
function bingoWinLogic() {
  let count = 0;
  let cells = document.querySelectorAll("td");
  console.log(cells);

  for (let row = 1; row < 6; row++) {
    cells.forEach((currentCell) => {
      if (
        currentCell.parentNode.id === "row" + row &&
        currentCell.style.backgroundColor === "indianred"
      ) {
        count++;
        if (count === 5) {
          alert("You Win!");
          location.reload();
        }
      } else {
        count = 0;
      }
    });
  }
}

function createTable() {
  let count = 0;
  let body = document.querySelector("body");

  let table = document.createElement("table");

  for (let row = 1; row < 6; row++) {
    let rows = document.createElement("tr");
    rows.setAttribute("id", "row" + row);
    table.appendChild(rows);
    for (let col = 1; col < 6; col++) {
      let cols = document.createElement("td");
      cols.setAttribute("id", "cell" + row + "" + col);
      cols.innerHTML = count;
      count++; //randomWordGenerator();
      cols.addEventListener("click", function (e) {
        cellClickHandler(cols);
      });
      rows.appendChild(cols);
    }
  }

  body.appendChild(table);
}

function cellClickHandler(cell) {
  console.log(cell.style.backgroundColor);
  if (cell.style.backgroundColor === "") {
    cell.style.backgroundColor = "indianred";
  } else if (cell.style.backgroundColor === "indianred") {
    cell.style.backgroundColor = "";
  }
}

function randomWordGenerator() {
  var things = [
    "Rock",
    "Paper",
    "Scissor",
    "Bob",
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "David",
    "Bingo",
    "Car",
    "Bike",
    "Maverick",
    "Top",
    "Gun",
    "Star Wars",
    "lorem",
  ];
  var thing = things[Math.floor(Math.random() * things.length)];
  return thing;
}
