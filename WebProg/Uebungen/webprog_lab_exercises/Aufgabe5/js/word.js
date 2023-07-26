class Word {
  static format = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/;
  constructor(word) {
    this.word = word;
  }

  randomize() {
    let result = "";
    if (this.word.length > 0) {
      let end = "";
      result += this.word[0];
      let lenght = this.word.length;

      if (Word.format.test(this.word[0])) {
        result += this.word[1];
        lenght--;
      }

      if (Word.format.test(this.word[this.word.length - 1])) {
        end = this.word[this.word.length - 2];
        lenght--;
      }

      for (let i = 0; i < lenght - 2; i++) {
        result += this.word[Math.floor(Math.random() * this.word.length)];
      }

      result += end;
      result += this.word[this.word.length - 1];
    }
    return result;
  }
}

export { Word };
