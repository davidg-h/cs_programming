function initAssignment() {
  const standardMain = document.querySelector("main");
  let articleList = document.querySelectorAll("article");

  articleList.forEach((article) => {
    scrambleWords(article);
  });

  let articleSubmit = document.querySelector("aside");

  let title = document.createElement("input");
  let titleLabel = document.createElement("label");
  titleLabel.textContent = "Titel";
  title.setAttribute("type", "text");
  title.setAttribute("id", "title");
  title.setAttribute("name", title.textContent);
  titleLabel.setAttribute("for", "titel");
  articleSubmit.appendChild(titleLabel);
  articleSubmit.appendChild(title);

  let textArea = document.createElement("textarea");
  textArea.setAttribute("type", "text");
  textArea.setAttribute("rows", "8");
  textArea.setAttribute("cols", "50");
  textArea.setAttribute("id", "newArticleText");
  textArea.setAttribute("name", textArea.textContent);
  articleSubmit.appendChild(textArea);

  let submitB = document.createElement("button");
  submitB.setAttribute("type", "sumbit");
  submitB.setAttribute("id", "articleSubmit");
  submitB.textContent = "Absenden";
  submitB.addEventListener("click", function () {
    let main = document.querySelector("main");
    let article = document.createElement("article");
    let title = document.querySelector("#title");
    let text = document.querySelector("#newArticleText");
    article.innerHTML += "<h2>" + title.value + "</h2>";
    article.innerHTML += "<p>" + text.value + "</p>";
    scrambleWords(article);
    title.value = "";
    text.value = "";
    main.appendChild(article);
  });
  articleSubmit.appendChild(submitB);

  let resetB = document.createElement("button");
  resetB.setAttribute("type", "sumbit");
  resetB.setAttribute("id", "siteReset");
  resetB.textContent = "Seite zurücksetzen";
  resetB.addEventListener("click", function () {
    let mainReset = document.createElement("main");
    let articleS1 = document.querySelector("#wortberge");
    let articleS2 = document.querySelector("#kafka");
    mainReset.appendChild(articleS1);
    mainReset.appendChild(articleS2);
    document
      .querySelector(".main_aside_container")
      .replaceChild(mainReset, document.querySelector("main"));
  });
  articleSubmit.appendChild(resetB);
}

function scrambleWords(article) {
  let innerHTML = article.innerHTML;
  let text = article.textContent;
  article.addEventListener(
    "mouseover",
    (event) => {
      const wordsArray = text.split(" ");
      let newText = "";
      wordsArray.forEach((word) => {
        let scramble = new Word(word);
        newText += scramble.randomize() + " ";
      });
      article.textContent = newText;
    },
    false
  );

  article.addEventListener(
    "mouseout",
    (event) => {
      article.innerHTML = innerHTML;
    },
    false
  );
}
