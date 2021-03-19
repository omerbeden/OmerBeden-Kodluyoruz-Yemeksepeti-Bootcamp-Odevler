import Header from "./Header";
import { faCheck } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const ComletedTodo = (props) => {
  const { todos } = props;

  return (
    <div
      style={{
        margin: "auto",
        marginTop: "20px",
        width: "50%",
        backgroundColor: "#4682b4",
      }}
    >
      <Header name="Completed Todos"></Header>
      {todos.map((todo) => (
        <div
          key={todo.id}
          style={{
            fontSize: "14pt",
            display: "flex",
            justifyContent: "center",
          }}
        >
          <FontAwesomeIcon
            icon={faCheck}
            size="lg"
            color="#006400"
          ></FontAwesomeIcon>
          <span>{todo.text}</span>
        </div>
      ))}
    </div>
  );
};

export default ComletedTodo;
