class BingoView {
  constructor() {
    this.winTimerId = -1;
  }

  generateTile(contentText, clickHandler) {
    let tile = document.createElement("div");
    tile.setAttribute("class", "tile");
    tile.setAttribute("data-active", "no");
    let content = document.createElement("p");
    content.textContent = contentText;
    tile.appendChild(content);
    tile.addEventListener("click", clickHandler);

    return tile;
  }

  generateGameField(xdim, ydim, contentTextArray, clickHandler) {
    let field = document.createElement("section");
    field.setAttribute("id", "field");

    for (let j = 0; j < ydim; ++j) {
      let tileline = document.createElement("div");
      tileline.setAttribute("class", "tileline");
      for (let i = 0; i < xdim; ++i) {
        let index = i + j * xdim; // j + i * xdim does not rotate the field -> in mark muss dann aber x und y vertauscht werden
        let tile = this.generateTile(contentTextArray[index], clickHandler);
        tile.setAttribute("data-index", index);
        tileline.appendChild(tile);
      }
      field.appendChild(tileline);
    }

    return field;
  }

  displayGameView(baseElement, xdim, ydim, contentTextArray, clickHandler) {
    this.baseElement = baseElement;
    let header = document.createElement("h1");
    header.textContent = "BiNGO!";
    baseElement.appendChild(header);
    baseElement.appendChild(
      this.generateGameField(xdim, ydim, contentTextArray, clickHandler)
    );
  }

  displayWin(resetHandler) {
    let btn = document.createElement("button");
    btn.textContent = "Congratulations! Do you want to restart?";
    btn.style.marginTop = "2em";
    btn.onclick = resetHandler;
    this.baseElement.appendChild(btn);

    let selectedTiles = this.baseElement.querySelectorAll("#field .tile");
    let stArray = Array.from(selectedTiles);

    this.winTimerId = setInterval(() => {
      stArray.forEach((elem) => {
        let r = Math.floor(Math.random() * 256).toString(16);
        r = r.padEnd(2, "0");
        let g = Math.floor(Math.random() * 256).toString(16);
        g = g.padEnd(2, "0");
        let b = Math.floor(Math.random() * 256).toString(16);
        b = b.padEnd(2, "0");

        elem.setAttribute("style", "background-color: #" + r + g + b + ";");
      });
    }, 750);
  }

  reset() {
    clearInterval(this.winTimerId);
    this.baseElement.innerHTML = "";
  }
}

export { BingoView };
