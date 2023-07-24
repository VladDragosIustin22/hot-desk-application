import { grey, orange } from "@mui/material/colors";
import { Box, Button, Typography, Toolbar, AppBar } from "@mui/material";
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
            <CloseIcon sx={{ marginLeft: 92 }}></CloseIcon>
          </Toolbar>
        </AppBar>
        <Box
          sx={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            width: "100%",
            p: 2,
            mb: 2,
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
              p: 2,
            }}
          ></Box>
          <Box sx={{ justifyContent: "flex-start", mt: 2, marginTop: 10 }}>
            <Button
              variant="contained"
              size="large"
              color="secondary"
              sx={{
                height: "50px",
                color: "white",
                textTransform: "none",
              }}
            >
              Save
            </Button>
          </Box>
        </Box>
      </Box>
    </ThemeProvider>
  );
}
