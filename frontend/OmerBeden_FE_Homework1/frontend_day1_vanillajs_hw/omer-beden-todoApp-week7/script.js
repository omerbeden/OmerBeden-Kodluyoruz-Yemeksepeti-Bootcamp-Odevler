const button = document.getElementById("button-save");
const textInput = document.querySelector(".input-todo");
const ulList = document.getElementById("ul-list");
const taskList = [];

function fillTaskListArray() {
  let keys = Object.keys(localStorage);
  for (let i = keys.length - 1; i >= 0; i--) {
    taskList.push(localStorage.getItem(keys[i]));
  }
}
fillTaskListArray();

function createListItems() {
  let listElements = "";
  taskList.map((item, index) => {
    let li = document.createElement("li");
    let removeBtn = document.createElement("button");
    removeBtn.setAttribute("id", `btn_sil_${index}`);
    removeBtn.innerHTML = "Sil";
    li.setAttribute("id", `li_${index}`);
    li.innerHTML = item;
    li.appendChild(removeBtn);

    ulList.appendChild(li);
  });
}
createListItems();

function deleteListItems() {
  taskList.map((item, index) => {
    document
      .getElementById("btn_sil_" + index)
      .addEventListener("click", function () {
        delete taskList[index];
        document.getElementById("li_" + index).remove();
        localStorage.removeItem(index + 1);
      });
  });
}
deleteListItems();

button.addEventListener("click", function (e) {
  let key = getLastKeyFromLocalStorage() + 1;
  localStorage.setItem(key.toString(), textInput.value);
  taskList.push(textInput.value);
  createListItems();
  deleteListItems();
});

function getLastKeyFromLocalStorage() {
  let lastKey = localStorage.length;
  return parseInt(lastKey);
}
