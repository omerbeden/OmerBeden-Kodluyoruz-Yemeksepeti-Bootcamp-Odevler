import "./App.css";

import Header from "./components/Header";
import TodoList from "./components/TodoList";

function App() {
  return (
    <div>
      <Header name="Todo App"></Header>
      <TodoList></TodoList>
    </div>
  );
}

export default App;
