import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { useFormik} from "formik";
import * as Yup from "yup";

const defaultTheme = createTheme();

interface Values {
  firstName : string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword : string;
}
const passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{5,}$/;

const schema = Yup.object().shape({
  firstName : Yup.string().required("Required"),
  lastName : Yup.string().required("Required"),
  email: Yup.string().email("Email shuld be valid! Example: bob.golden@gmail.com").required("Required"),
  password: Yup.string().min(8).matches(passwordRegex,{message: " Please create a stronger password! At least 1 upper case letter, 1 lower case letter, 1 numeric digit"}).required("Required"),
  confirmPassword : Yup.string().oneOf([Yup.ref("password"), ""],"Passwords must match!").required("Required")
});

const handleSubmit = () => {
  console.log("Submitted")
} 
export default function SignUp() {

  const formik = useFormik<Values>({
    initialValues : {
      firstName :"",
      lastName : "",
      email: '',
      password: '',
      confirmPassword : "",
    },
    validationSchema: schema,
    onSubmit: handleSubmit,
  });

  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign up
          </Typography>
          <Box
            component="form"
            onChange={formik.handleChange}
            onSubmit={formik.handleSubmit} 
            onBlur={formik.handleBlur}
            sx={{ mt: 3 }}
          >
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  name="firstName"
                  required
                  fullWidth
                  value={formik.values.firstName}
                  id="firstName"
                  label="First Name"
                  autoFocus
                  error={formik.touched.firstName && Boolean(formik.errors.firstName)}
                  helperText={formik.touched.firstName && formik.errors.firstName}
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  autoFocus
                  required
                  fullWidth
                  id="lastName"
                  value = {formik.values.lastName}
                  label="Last Name"
                  name="lastName"
                  error={formik.touched.lastName && Boolean(formik.errors.lastName )}
                  helperText={formik.touched.lastName  && formik.errors.lastName }
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="email"
                  value = {formik.values.email}
                  label="Email Address"
                  name="email"
                  autoFocus
                  error={formik.touched.email && Boolean(formik.errors.email)}
                  helperText={formik.touched.email && formik.errors.email}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  autoFocus
                  required
                  fullWidth
                  name="password"
                  value = {formik.values.password}
                  label="Password"
                  type="password"
                  id="password"
                  error={formik.touched.password && Boolean(formik.errors.password)}
                  helperText={formik.touched.password && formik.errors.password}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  autoFocus
                  required
                  fullWidth
                  value={formik.values.confirmPassword}
                  name="confirmPassword"
                  label="Confirm Password"
                  type="password"
                  id="confirmPassword"
                  error={formik.touched.confirmPassword && Boolean(formik.errors.confirmPassword)}
                  helperText={formik.touched.confirmPassword && formik.errors.confirmPassword}
                />
              </Grid>
              <Grid item xs={12}>
                <FormControlLabel
                  control={
                    <Checkbox value="allowExtraEmails" color="primary" />
                  }
                  label="I want to receive inspiration, marketing promotions and updates via email."
                />
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </Button>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <Link href="/login-page" variant="body2">
                  Already have an account? Sign in
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
