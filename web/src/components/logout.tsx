import { Link } from '@mui/material';
import React from 'react';
import { useNavigate } from 'react-router-dom';


export default function Logout(){
   

    localStorage.removeItem('token-info');
    localStorage.clear();
    alert("Logged out!");
}