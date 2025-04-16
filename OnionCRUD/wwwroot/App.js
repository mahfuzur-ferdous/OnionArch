const apiUrl = "http://localhost:19352/api/ToDo";

document.addEventListener("DOMContentLoaded", () => {
    loadTodos();

    document.getElementById("todoForm").addEventListener("submit", async (e) => {
        e.preventDefault();
        const title = document.getElementById("title").value;
        const description = document.getElementById("description").value;

        await fetch(`${apiUrl}/add`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                title,
                description,
                isCompleted: false,
                createdAt: new Date().toISOString(),
            }),
        });

        e.target.reset();
        loadTodos();
    });
});

async function loadTodos() {
    const res = await fetch(`${apiUrl}/getall`);
    const todos = await res.json();
    const list = document.getElementById("todoList");
    list.innerHTML = "";

    if (todos.length === 0) {
        list.innerHTML = '<p class="empty-message">No tasks found. Add one above!</p>';
        return;
    }

    todos.forEach((todo) => {
        const item = document.createElement("div");
        item.className = `todo-item ${todo.isCompleted ? "complete" : ""}`;
        item.dataset.id = todo.id;
        item.innerHTML = `
      <div class="todo-content">
        <strong>${todo.title}</strong>
        <small>${todo.description}</small>
      </div>
      <div class="todo-actions">
        <button class="complete-btn" onclick="toggleComplete(${todo.id}, ${todo.isCompleted})">
          <i class="fas fa-${todo.isCompleted ? "undo" : "check"}"></i>
        </button>
        <button class="edit-btn" onclick="editTodo(${todo.id})">
          <i class="fas fa-edit"></i>
        </button>
        <button class="delete-btn" onclick="deleteTodo(${todo.id})">
          <i class="fas fa-trash"></i>
        </button>
      </div>
    `;
        list.appendChild(item);
    });
}

async function deleteTodo(id) {
    if (!confirm("Are you sure you want to delete this task?")) return;

    await fetch(`${apiUrl}/${id}`, { method: "DELETE" });
    loadTodos();
}

async function toggleComplete(id, isCompleted) {
    const res = await fetch(`${apiUrl}/get/${id}`);
    const todo = await res.json();
    todo.isCompleted = !isCompleted;

    await fetch(`${apiUrl}/edit/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(todo),
    });

    loadTodos();
}

function editTodo(id) {
    window.location.href = `edit.html?id=${id}`;
}