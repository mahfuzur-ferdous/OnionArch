const apiUrl = "http://localhost:19352/api/ToDo";
const urlParams = new URLSearchParams(window.location.search);
const taskId = urlParams.get('id');

document.addEventListener("DOMContentLoaded", async () => {
    if (!taskId) {
        window.location.href = 'index.html';
        return;
    }

    try {
        // Load task data
        const res = await fetch(`${apiUrl}/get/${taskId}`);
        if (!res.ok) {
            throw new Error('Failed to fetch task');
        }

        const task = await res.json();
        if (!task) {
            throw new Error('Task not found');
        }

        // Pre-fill form
        document.getElementById('editTitle').value = task.title || '';
        document.getElementById('editDescription').value = task.description || '';
        document.getElementById('editIsCompleted').checked = task.isCompleted || false;

        // Cancel button
        document.getElementById('cancelBtn').addEventListener('click', () => {
            window.location.href = 'index.html';
        });

        // Form submission
        document.getElementById('editForm').addEventListener('submit', async (e) => {
            e.preventDefault();

            const updatedTask = {
                id: parseInt(taskId), // Ensure ID is number if backend expects it
                title: document.getElementById('editTitle').value,
                description: document.getElementById('editDescription').value,
                isCompleted: document.getElementById('editIsCompleted').checked,
                createdAt: task.createdAt // Preserve original creation date
            };

            console.log('Sending update:', updatedTask); // Debug log

            try {
                const response = await fetch(`${apiUrl}/edit/${taskId}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                        'Accept': 'application/json'
                    },
                    body: JSON.stringify(updatedTask)
                });

                console.log('Update response:', response); // Debug log

                if (!response.ok) {
                    const errorData = await response.json();
                    throw new Error(errorData.message || 'Failed to update task');
                }

                // Check if response has data
                const responseData = await response.json();
                console.log('Update successful:', responseData);

                window.location.href = 'index.html';
            } catch (error) {
                console.error('Update error:', error);
                alert(`Error: ${error.message}`);
            }
        });

    } catch (error) {
        console.error('Initialization error:', error);
        alert(`Error: ${error.message}`);
        window.location.href = 'index.html';
    }
});