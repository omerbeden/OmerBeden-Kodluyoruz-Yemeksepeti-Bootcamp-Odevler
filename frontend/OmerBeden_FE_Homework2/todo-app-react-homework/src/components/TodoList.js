import React from "react";
import Todo from "./Todo";
import TodoInput from "./TodoInput";
import ComletedTodo from "./compeletedTodo";

export default class TodoList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      todos: this.fillState(),
    };
  }

  fillState() {
    let keys = Object.keys(localStorage);
    let initial = [];
    for (let i = keys.length - 1; i >= 0; i--) {
      initial.push(JSON.parse(localStorage.getItem(keys[i])));
    }

    return initial;
  }

  addTodo = (todo) => {
    this.setState({
      todos: [todo, ...this.state.todos],
    });

    localStorage.setItem(todo.id, JSON.stringify(todo));
  };

  handleDelete = (id) => {
    this.setState({
      todos: this.state.todos.filter((todo) => todo.id !== id),
    });
    localStorage.removeItem(id);
  };

  handleComleted = (id) => {
    this.setState({
      todos: this.state.todos.map((todo) => {
        if (todo.id === id) {
          let obj = { ...todo, complete: !todo.complete };
          localStorage.setItem(todo.id, JSON.stringify(obj));
          return obj;
        } else {
          return todo;
        }
      }),
    });
  };

  render() {
    let completedTodos = this.state.todos.filter((todo) => todo.complete);
    return (
      <div>
        <div
          style={{
            margin: "auto",
            marginTop: "20px",
            padding: "20px",
          }}
        >
          <TodoInput onSubmit={this.addTodo} />
          {this.state.todos.map((todo) => (
            <Todo
              key={todo.id}
              todo={todo}
              onComplete={() => this.handleComleted(todo.id)}
              onDelete={() => this.handleDelete(todo.id)}
            />
          ))}
        </div>

        {completedTodos.length > 0 ? (
          <ComletedTodo todos={completedTodos}></ComletedTodo>
        ) : null}
      </div>
    );
  }
}
