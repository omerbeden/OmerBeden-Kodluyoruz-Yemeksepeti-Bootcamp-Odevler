import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashAlt } from "@fortawesome/free-solid-svg-icons";

const Todo = (props) => {
  const { todo, onComplete, onDelete } = props;

  const handleCheck = () => {
    onComplete();
  };

  const defaultCheck = () => {
    return todo.complete ? true : false;
  };

  const handleDelete = () => {
    onDelete();
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        marginBottom: "20px",
        color: todo.complete ? "#006400" : "black",
        fontWeight: todo.complete ? "bold" : "normal",
      }}
    >
      <input
        style={{ width: "20px", height: "20px" }}
        type="checkbox"
        defaultChecked={defaultCheck()}
        onChange={handleCheck}
      />
      <span style={{ marginLeft: "5px" }}></span>
      {todo.text}
      <span style={{ marginLeft: "5px" }}></span>
      <FontAwesomeIcon
        icon={faTrashAlt}
        color="#ab4e52"
        size="lg"
        onClick={handleDelete}
      ></FontAwesomeIcon>
    </div>
  );
};

export default Todo;
