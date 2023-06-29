import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { useFormik} from "formik";
import * as Yup from "yup";
import { useState } from 'react';
import { IconButton, InputAdornment } from '@mui/material';
import {Visibility,VisibilityOff} from '@mui/icons-material'

function Copyright(props: any) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit" href="https://mui.com/">
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const defaultTheme = createTheme();
const passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{5,}$/;

interface Values {
  email: string;
  password: string;
}

const handleSubmit = () => {
  console.log("Submitted")
} 

const schema = Yup.object().shape({
  email: Yup.string().email("Email shuld be valid! Example: bob.golden@gmail.com").required("Required"),
  password: Yup.string().min(8).matches(passwordRegex,{message: " Please create a stronger password! At least 1 upper case letter, 1 lower case letter, 1 numeric digit"}).required("Required")
})

export default function LogIn() {
  
  const [showPassword, setShowPassword] = useState(false);

  const handleClickShowPassword = () => setShowPassword((show) => !show);

  const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.preventDefault();
  };
  const formik = useFormik<Values>({
    initialValues : {
      email: '',
      password: '',
    },
    validationSchema: schema,
    onSubmit: handleSubmit,
  });
  console.log(formik)

  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1"  variant="h5">
            Sign in
          </Typography>
          <Box component="form" onChange={formik.handleChange} onSubmit={formik.handleSubmit} onBlur={formik.handleBlur} sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              value ={formik.values.email}
              id="email"
              label="Email Address"
              name="email"
              autoFocus
              error={formik.touched.email && Boolean(formik.errors.email)}
              helperText={formik.touched.email && formik.errors.email}
              
            />
            <TextField
              margin="normal"
              value ={formik.values.password}
              required
              fullWidth
              name="password"
              label="Password"
              id="password"
              type={showPassword ? 'text' : 'password'}
              error={formik.touched.password && Boolean(formik.errors.password)}
              helperText={formik.touched.password && formik.errors.password}
              InputProps={
                {
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                      >
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                )
               }
              }
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign In
            </Button>
            <Grid container>
              <Grid item>
                <Link href="/sign-up-page" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}