import { useState, useEffect } from 'react';
import axios from 'axios';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button, Box, TextField } from '@mui/material';

const TaskList = () => {
  const [input, setInput] = useState('')
  const [tasks, setTasks] = useState([])

  useEffect(() => {
    const fetchTasks = async () => {
      try {
        const token = localStorage.getItem('token');
        const response = await axios.get('http://localhost:5002/tasks', {
          headers: { Authorization: `Bearer ${token}` }
        });
        setTasks(response.data);
      } catch (error) {
        console.error('Error fetching tasks:', error);
      }
    };

    fetchTasks();
  }, []);

  const handleAdd = async (title) => {
    try {
      const token = localStorage.getItem('token');

      const response = await axios.post(`http://localhost:5002/tasks`,
        {
          title,
          status: 'pending'
        },
        {
          headers: { Authorization: `Bearer ${token}` },
        }
      );

      setTasks([...tasks, { id: response.data.id, title, status: 'pending' }]);
    } catch (error) {
      console.error('Error adding task:', error);
    }
  };

  const handleDelete = async (id) => {
    try {
      const token = localStorage.getItem('token');
      await axios.delete(`http://localhost:5002/tasks/${id}`,
        {
          headers: { Authorization: `Bearer ${token}` }
        }
      );

      setTasks(tasks.filter(task => task.id !== id));
    } catch (error) {
      console.error('Error deleting task:', error);
    }
  };

  return (
    <>
      <Box>
        <TextField
          label="New Task"
          value={input}
          onChange={(e) => setInput(e.target.value)}
          fullWidth
          margin="normal"
        />

        <Button variant="contained" disabled={input.length === 0} onClick={() => handleAdd(input)}>
          Add Task
        </Button>
      </Box>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell>Title</TableCell>
              <TableCell>Status</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tasks.map(task => (
              <TableRow key={task.id}>
                <TableCell>{task.id}</TableCell>
                <TableCell>{task.title}</TableCell>
                <TableCell>{task.status}</TableCell>
                <TableCell>
                  <Button color="error" onClick={() => handleDelete(task.id)}>
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer >
    </>
  );
};

export default TaskList;