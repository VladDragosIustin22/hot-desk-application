import { grey, orange } from "@mui/material/colors";
import {
  Box,
  Button,
  Typography,
  Toolbar,
  AppBar,
  Select,
  FormControl,
  InputLabel,
  MenuItem,
  FormControlLabel,
  Switch,
  FormGroup,
} from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import CloseIcon from "@mui/icons-material/Close";
import React from "react";
import SettingsIcon from "@mui/icons-material/Settings";

const theme = createTheme({
  palette: {
    primary: {
      main: grey[700],
    },
    secondary: {
      main: orange[900],
    },
  },
  typography: {
    fontSize: 17,
  },
});

function Settings() {
  const [language, setLanguage] = React.useState("");
  const handleLanguageChange = (event: {
    target: { value: React.SetStateAction<string> };
  }) => {
    setLanguage(event.target.value);
  };
  const [office, setOffice] = React.useState("");
  const handleOfficeChange = (event: {
    target: { value: React.SetStateAction<string> };
  }) => {
    setOffice(event.target.value);
  };

  const [emailNotifications, setEmailNotifications] =
    React.useState<boolean>(false);

  const handleEmailNotificationsToggle = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setEmailNotifications(event.target.checked);
  };

  const [phoneNotifications, setPhoneNotifications] =
    React.useState<boolean>(false);

  const handlePhoneNotificationsToggle = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setPhoneNotifications(event.target.checked);
  };

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
        
        <Box
          sx={{
            display: "flex",
            justifyContent: "flex-end",
            alignItems: "center",
            width: "100%",
            p: 2,
            mb: 2,
            height: "100%",
          }}
        >
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              flexDirection: "column",
              alignItems: "flex-start",
              width: "100%",
              mt: 4,
              p: 2,
            }}
          ></Box>

          <Box sx={{ justifyContent: "flex-start", mt: 40, marginBottom: -90 }}>
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
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "left",
          mt: 2,
        }}
      >
        <FormControl sx={{ width: "40ch", mb: 6, mt: -5 }}>
          <InputLabel id="select-language">Language</InputLabel>
          <Select
            labelId="select-language"
            id="select-language"
            value={language}
            label="Language"
            onChange={handleLanguageChange}
          >
            <MenuItem value={10}>English</MenuItem>
            <MenuItem value={20}>French</MenuItem>
            <MenuItem value={30}>German</MenuItem>
          </Select>
        </FormControl>

        <FormControl sx={{ width: "40ch", mb: 6 }}>
          <InputLabel id="select-favorite-office">Favorite Office</InputLabel>
          <Select
            labelId="select-favorite-office"
            id="select-favorite-office"
            value={office}
            label="Office"
            onChange={handleOfficeChange}
          >
            <MenuItem value={11}>Predeal</MenuItem>
            <MenuItem value={12}>Brizei</MenuItem>
          </Select>
        </FormControl>

        <FormGroup sx={{ mr: 80, ml: 0, width: "40ch", gap: 4 }}>
          <FormControlLabel
            control={
              <Switch
                checked={emailNotifications}
                onChange={handleEmailNotificationsToggle}
              />
            }
            label="E-mail notifications"
          />
          <FormControlLabel
            control={
              <Switch
                checked={phoneNotifications}
                onChange={handlePhoneNotificationsToggle}
              />
            }
            label="Phone notifications"
          />
        </FormGroup>
      </Box>
    </ThemeProvider>
  );
}
export default Settings;
