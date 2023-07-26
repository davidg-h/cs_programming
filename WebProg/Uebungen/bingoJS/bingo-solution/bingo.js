
/** Missing: Game data text **/

class Bingo {
  constructor(xdim, ydim) {
    this.xdim = xdim;
    this.ydim = ydim;
    this.reset();
  }

  reset() {
    this.content = [];
    this.rowSums = [];
    this.colSums = [];
    this.diagSum = 0;
    this.backDiagSum = 0;

    for (let i = 0; i < this.xdim; ++i) {
      this.colSums[i] = 0;
    }
    for (let i = 0; i < this.ydim; ++i) {
      this.rowSums[i] = 0;
    }
    for (let i = 0; i < this.xdim; ++i) {
      for (let j = 0; j < this.ydim; j++) {
        let index = i + j * this.xdim;
        this.content[index] = Math.floor(Math.random()*255);
      }
    }
  }

  mark(index) {
    let x = index % this.xdim;
    let y = Math.floor(index / this.xdim);
  
    this.colSums[x] += 1;
    this.rowSums[y] += 1;
    if (this.xdim === this.ydim) {
      if (x===y) this.diagSum += 1;
      if ((x+y) === this.xdim-1) this.backDiagSum += 1;
    }
  }

  unmark(index) {
    let x = index % this.xdim;
    let y = Math.floor(index / this.xdim);

    this.colSums[x] -= 1;
    this.rowSums[y] -= 1;
    if (this.xdim === this.ydim) {
      if (x===y) this.diagSum -= 1;
      if ((x+y) === this.xdim-1) this.backDiagSum -= 1;
    }
 
  }


  isWinner() {
    let winsRow = this.rowSums.indexOf(this.xdim) !== -1;
    let winsCol = this.colSums.indexOf(this.ydim) !== -1;
    let winsDiag = this.diagSum === this.xdim;
    let winsBackDiag = this.backDiagSum === this.xdim;

    return winsRow || winsCol || winsDiag || winsBackDiag;
  }
}

export { Bingo };