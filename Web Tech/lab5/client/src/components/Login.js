import { useState } from 'react';
import axios from 'axios';
import { TextField, Button, Box } from '@mui/material';
import { NavLink } from 'react-router-dom';

const Login = ({ onLogin }) => {
  const [formData, setFormData] = useState({
    username: '',
    password: ''
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('http://localhost:5002/login', formData);
      localStorage.setItem('token', response.data.access_token);
      onLogin(true);
    } catch (error) {
      console.error('Login error:', error);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit}>
      <TextField
        label="Username"
        value={formData.username}
        onChange={(e) => setFormData({ ...formData, username: e.target.value })}
        fullWidth
        margin="normal"
      />

      <TextField
        label="Password"
        type="password"
        value={formData.password}
        onChange={(e) => setFormData({ ...formData, password: e.target.value })}
        fullWidth
        margin="normal"
      />

      <Button type="submit" variant="contained" color="primary">
        Login
      </Button>

      <NavLink to="/register">or register</NavLink>
    </Box>
  );
};

export default Login;
