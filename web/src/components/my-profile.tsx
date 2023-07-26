import { grey, orange } from "@mui/material/colors";
import {
  Box,
  Button,
  Typography,
  Toolbar,
  AppBar,
  TextField,
  Avatar,
  Stack,
} from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import CloseIcon from "@mui/icons-material/Close";

import PersonOutlineIcon from "@mui/icons-material/PersonOutline";
const theme = createTheme({
  palette: {
    primary: {
      main: grey[900],
    },
    secondary: {
      main: orange[500],
    },
  },
  typography: {
    fontSize: 20,
  },
});

export default function MyProfile() {
  return (
    <ThemeProvider theme={theme}>
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <AppBar position="fixed" sx={{ width: "100%" }}>
          <Toolbar disableGutters>
            <PersonOutlineIcon
              sx={{
                display: { xs: "none", md: "flex" },
                mr: 1,
                fontSize: 40,
                marginLeft: 3,
              }}
            />{" "}
            <Typography variant="h6" component="div">
              My Profile
            </Typography>
            <CloseIcon sx={{ marginLeft: 36 }}></CloseIcon>
          </Toolbar>
        </AppBar>
        <Stack direction="row" spacing={2}>
          <Avatar
            alt="V"
            src="/static/images/avatar/1.jpg"
            sx={{ width: 100, height: 100, ml: -28, mr: -25, mt: 15 }}
          />
        </Stack>
        <Box
          sx={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            width: "100%",
            p: 2,
            mb: -10,
            mt: -28,
          }}
        >
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              flexDirection: "column",
              alignItems: "center",
              width: "100%",
              mt: 4,
              p: 1,
            }}
          ></Box>
          <Box
            component="form"
            sx={{
              "& .MuiTextField-root": {
                mb: -5,
                width: "40ch",
                mt: 10,
                mr: -12,
              },
            }}
            noValidate
            autoComplete="off"
          >
            <TextField
              label="Name"
              id="outlined-size-normal"
              defaultValue="Name"
            />

            <TextField
              label="Job title"
              id="outlined-size-normal"
              defaultValue="Job title"
            />

            <TextField
              label="E-mail"
              defaultValue="E-mail"
              InputProps={{
                style: {
                  width: "37ch",
                  marginLeft: "-160px",
                },
              }}
              InputLabelProps={{
                style: {
                  marginLeft: "-160px",
                },
                shrink: true,
              }}
            />
            <TextField
              label="Phone"
              defaultValue="+407********"
              InputProps={{
                style: {
                  width: "37ch",
                  marginLeft: "-160px",
                },
              }}
              InputLabelProps={{
                style: {
                  marginLeft: "-160px",
                },
                shrink: true,
              }}
            />
          </Box>

          <div>
            <Box
              sx={{
                justifyContent: "flex-start",
                mt: 40,
                marginBottom: -80,
                ml: -7,
              }}
            >
              <Button
                variant="contained"
                size="large"
                color="secondary"
                sx={{
                  height: "50px",
                  color: "white",
                  textTransform: "none",
                  p: 2,
                  ml: 1,
                }}
              >
                Save
              </Button>
            </Box>
          </div>
        </Box>
      </Box>
    </ThemeProvider>
  );
}
