import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import { nanoid } from "nanoid";

const TodoInput = (props) => {
  const [text, setText] = useState();

  const handleChange = (event) => {
    setText(event.target.value);
  };

  const handleSubmit = (event) => {
    if (text) {
      props.onSubmit({
        id: nanoid(),
        text: text,
        complete: false,
      });
    }
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        marginBottom: "20px",
      }}
    >
      <input
        style={{ fontSize: "14pt" }}
        type="text"
        size="50"
        onChange={handleChange}
        placeholder="Enter a Todo"
      ></input>

      <FontAwesomeIcon
        style={{ marginLeft: "10" }}
        size="4x"
        onClick={handleSubmit}
        icon={faPlus}
      ></FontAwesomeIcon>
    </div>
  );
};

export default TodoInput;
