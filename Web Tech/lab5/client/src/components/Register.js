import { useState } from 'react';
import axios from 'axios';
import { TextField, Button, Box, Alert } from '@mui/material';
import { NavLink } from 'react-router-dom';

const Register = () => {
  const [isSuccess, setIsSuccess] = useState(false);
  const [formData, setFormData] = useState({
    username: '',
    password: '',
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post('http://localhost:5002/register', formData);
      setIsSuccess(true)
    } catch (error) {
      console.error('Login error:', error);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit}>
      {isSuccess && <Alert severity="success">
        Registration successful. Please <NavLink to="/">login</NavLink>.
      </Alert>}

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
        Register
      </Button>

      <NavLink to="/">or login</NavLink>
    </Box>
  );
};

export default Register;
