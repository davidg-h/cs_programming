import { BingoView } from "./bingo_view.js";
import { Bingo } from "./bingo.js";

class BingoController {
  constructor(view, model) {
    this.view = view;
    this.model = model;
    this.didWin = false;
  }

  resetHandler() {
    this.view.reset();
    this.model.reset();
    this.didWin = false;
    this.initGame(this.mainElement);
  }

  userClickHandler(event) {
    let targetElement = event.currentTarget;
    let state = targetElement.getAttribute("data-active") === "yes";
    if (!this.didWin) {
      if (state) {
        targetElement.setAttribute("data-active", "no");
        let index = targetElement.getAttribute("data-index").valueOf();
        this.model.unmark(index);
      } else {
        targetElement.setAttribute("data-active", "yes");
        let index = targetElement.getAttribute("data-index").valueOf();
        this.model.mark(index);
      }
      if (this.model.isWinner()) {
        this.didWin = true;
        this.view.displayWin(this.resetHandler.bind(this));
      }
    }
  }

  initGame(element) {
    this.test = "added global";
    this.mainElement = element;
    this.test2 = "global overwrite";
    this.view.displayGameView(
      element,
      this.model.xdim,
      this.model.ydim,
      this.model.content,
      this.userClickHandler.bind(this)
    );
  }
}

document.body.onload = () => {
  let view = new BingoView();
  let game = new Bingo(3, 3);

  let bc = new BingoController(view, game);
  bc.initGame(document.getElementById("bingo"));
};
