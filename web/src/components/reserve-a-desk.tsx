import dayjs from 'dayjs';
import { DemoItem } from '@mui/x-date-pickers/internals/demo';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { TimePicker } from '@mui/x-date-pickers/TimePicker';
import { grey, blue } from '@mui/material/colors';
import {
  Box,
  Button,
  Typography,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
} from '@mui/material';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import React from 'react';
import { DateCalendar } from '@mui/x-date-pickers';

const theme = createTheme({
  palette: {
    primary: {
      main: blue[500],
    },
  },
  typography: {
    fontSize: 20,
  },
});

function BasicSelect() {
  const [headquarters, setHeadquarters] = React.useState('');
  const [floor, setFloor] = React.useState('');
  const [desk, setDesk] = React.useState('');

  const handleHeadquartersChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
    setHeadquarters(event.target.value);
  };

  const handleFloorChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
    setFloor(event.target.value);
  };

  const handleDeskChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
    setDesk(event.target.value);
  };

  return (
    <Box
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        mt: 2, 
      }}
    >
      <FormControl sx={{ width: '25ch', mb: 1 }}>
        <InputLabel id="select-headquarters">Headquarters</InputLabel>
        <Select
          labelId="select-headquarters"
          id="select-headquarters"
          value={headquarters}
          label="Headquarters"
          onChange={handleHeadquartersChange}
        >
          <MenuItem value={10}>Boston</MenuItem>
          <MenuItem value={20}>New York</MenuItem>
          <MenuItem value={30}>Chicago</MenuItem>
          <MenuItem value={40}>Las Vegas</MenuItem>
          <MenuItem value={50}>Los Angeles</MenuItem>
        </Select>
      </FormControl>

      <FormControl sx={{ width: '25ch', mb: 1 }}>
        <InputLabel id="select-floor">Floor</InputLabel>
        <Select
          labelId="select-floor"
          id="select-floor"
          value={floor}
          label="Floor"
          onChange={handleFloorChange}
        >
          <MenuItem value={11}>1</MenuItem>
          <MenuItem value={12}>2</MenuItem>
          <MenuItem value={13}>3</MenuItem>
          <MenuItem value={14}>4</MenuItem>
          <MenuItem value={15}>5</MenuItem>
        </Select>
      </FormControl>

      <FormControl sx={{ width: '25ch', mb: 1 }}>
        <InputLabel id="select-desk">Desk</InputLabel>
        <Select
          labelId="select-desk"
          id="select-desk"
          value={desk}
          label="Desk"
          onChange={handleDeskChange}
        >
          <MenuItem value={16}>1</MenuItem>
          <MenuItem value={17}>2</MenuItem>
          <MenuItem value={18}>3</MenuItem>
          <MenuItem value={19}>4</MenuItem>
          <MenuItem value={20}>5</MenuItem>
        </Select>
      </FormControl>
    </Box>
  );
}


function ReserveDesk() {
  const [city, setCity] = React.useState('');

  const handleChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
    setCity(event.target.value);
  };

  return (
    <ThemeProvider theme={theme}>
      <Box
        sx={{
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          justifyContent: 'center',
          minHeight: '100vh',
        }}
      >
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'space-between',
            alignItems: 'center',
            width: '100%',
            p: 2,
          }}
        >
          <Typography variant="h6" sx={{ fontSize: '50px', mx: 'auto' }}>
            Reserve a desk
          </Typography>

          <Button variant="contained" size="large">
            Save
          </Button>
        </Box>

        <Box
          sx={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            mt: 4,
          }}
        >
          <DemoItem label="Date:" component="DatePicker">
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DateCalendar />
            </LocalizationProvider>
          </DemoItem>

          <DemoItem label="Time:" component="TimePicker">
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <div style={{ display: 'flex', alignItems: 'center' }}>
                <TimePicker
                  defaultValue={dayjs()}
                  sx={{
                    '& .MuiOutlinedInput-root': {
                      borderColor: grey[900],
                    },
                    '& .MuiOutlinedInput-notchedOutline': {
                      borderColor: grey[900],
                    },
                    '& .MuiOutlinedInput-input': {
                      color: grey[900],
                    },
                  }}
                />
                <Typography
                  variant="body1"
                  component="span"
                  style={{ margin: '0 10px' }}
                >
                  to
                </Typography>
                <TimePicker
                  defaultValue={dayjs()}
                  sx={{
                    '& .MuiOutlinedInput-root': {
                      borderColor: grey[900],
                    },
                    '& .MuiOutlinedInput-notchedOutline': {
                      borderColor: grey[900],
                    },
                    '& .MuiOutlinedInput-input': {
                      color: grey[900],
                    },
                  }}
                />
              </div>
            </LocalizationProvider>
          </DemoItem>

          <BasicSelect />
        </Box>
      </Box>
    </ThemeProvider>
  );
}

export default ReserveDesk;