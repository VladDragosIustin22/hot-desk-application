import dayjs, { Dayjs } from "dayjs";
import { DemoItem } from "@mui/x-date-pickers/internals/demo";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { TimePicker } from "@mui/x-date-pickers/TimePicker";
import { grey, orange } from "@mui/material/colors";
import {
  Box,
  Button,
  Typography,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  AppBar,
  Toolbar,
  SelectChangeEvent,
} from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import React, { useEffect, useState } from "react";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { TimeView } from "@mui/x-date-pickers";
import FormGroup from "@mui/material/FormGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import Switch from "@mui/material/Switch";
import MobileFriendlyIcon from "@mui/icons-material/MobileFriendly";
import CloseIcon from "@mui/icons-material/Close";
import { ReservationSetUp } from "../models/reservationSetup";
import { Reservation } from "../models/reservation";

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
    fontSize: 20,
  },
});


function DatePickerValue({
  allDay,
  handleAllDayToggle,
  value,
  setValue,
  setDateCompleted,
}: any) {
  const handleDateChange = (newValue: Dayjs | null) => {
    setValue(newValue);
    if (newValue) {
      setDateCompleted(true);
    } else {
      setDateCompleted(false);
    }
  };

  return (
    <FormControl sx={{ width: "64ch", mb: 5 }}>
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <Box sx={{ display: "flex", alignItems: "center" }}>
          <DatePicker
            label="Date"
            value={value}
            onChange={handleDateChange}
            sx={{ width: "64ch" }}
          />

          <FormGroup sx={{ mr: -20, ml: "auto" }}>
            <FormControlLabel
              control={
                <Switch checked={allDay} onChange={handleAllDayToggle} />
              }
              label="All day"
            />
          </FormGroup>
        </Box>
      </LocalizationProvider>
    </FormControl>
  );
}
function BasicSelect({
  startTime,
  endTime,
  value,
  isDateCompleted,
  isTimeCompleted,
}: {
  startTime : any
  endTime : any,
  value: any,
  isDateCompleted: boolean;
  isTimeCompleted: boolean;
}) {

  const [reservationSetUp,setReservationSetUp] = useState<ReservationSetUp[] | null>(null);
  const [selectedOfficeID, setSelectedOfficeID] = useState('');
  const [selectedFloorID, setSelectedFloorID] = useState('');
  const [selectedDeskID, setSelectedDeskID] = useState('');
 
  const[arrivalTime,setArrivalTime] = React.useState<Dayjs | null>(dayjs()
  );
  const [leavingTime, setLeavingTime] = React.useState<Dayjs | null>(
    dayjs()
  );
  
  const [reservation,setReservation] = useState<Reservation | null>(null);
  const createReservation =() =>{
    const reservationData : Reservation ={
      arrivalTime : arrivalTime?.toDate() || new Date(),
      leavingTime : leavingTime?.toDate() || new Date(),
      officeID : selectedOfficeID,
      floorID : selectedFloorID,
      deskID :selectedDeskID,
    };
    setReservation(reservationData);

    
  }
  console.log(reservation);
  useEffect(() => {
    if (value) {
      const datePart = value.format("YYYY-MM-DD");
      if (startTime) {
        setArrivalTime(dayjs(`${datePart}T${startTime.format("HH:mm:ss")}`));
      }
      if (endTime) {
        setLeavingTime(dayjs(`${datePart}T${endTime.format("HH:mm:ss")}`));
      }
    }
  }, [startTime,endTime,value]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const token = localStorage.getItem("authToken");
        
        const response = await fetch(`https://localhost:7156/api/Desk/availableDesks?arrivalTime=${arrivalTime}&leavingTime=${leavingTime}`, {
          method: "GET",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        const data = await response.json();
        setReservationSetUp(data)
        console.log(reservationSetUp);
      } catch (error) {
        console.error('Unknown error occurred:', error);
      }
    };
    fetchData();
  }, [arrivalTime, leavingTime, value, startTime, endTime]);


  const uniqueOffices: ReservationSetUp[] = reservationSetUp
  ? reservationSetUp.reduce((acc: ReservationSetUp[], curr: ReservationSetUp) => {
      if (!acc.find((item: ReservationSetUp) => item.officeID === curr.officeID)) {
        acc.push(curr);
      }
      return acc;
    }, [])
    .map((reservationSetUp: ReservationSetUp) => ({
      officeID: reservationSetUp.officeID,
      officeName: reservationSetUp.officeName,
      floorID : reservationSetUp.floorID,
      floorName : reservationSetUp.floorName,
      deskID : reservationSetUp.deskID,
      deskName : reservationSetUp.deskName
    }))
  : [];

  const uniqueFloors: ReservationSetUp[] = reservationSetUp
  ? reservationSetUp.filter((curr: ReservationSetUp, index: number, arr: ReservationSetUp[]) => {
      const firstIndex = arr.findIndex((item) => item.floorID === curr.floorID);
      
      return index === firstIndex && curr.officeID === selectedOfficeID;

    })
    .map((reservationSetUp: ReservationSetUp) => ({
      officeID: reservationSetUp.officeID,
      officeName: reservationSetUp.officeName,
      floorID: reservationSetUp.floorID,
      floorName: reservationSetUp.floorName,
      deskID: reservationSetUp.deskID,
      deskName: reservationSetUp.deskName,
    }))
  : [];
  // console.log(uniqueFloors)
  const uniqueDesks: ReservationSetUp[] = reservationSetUp
  ? reservationSetUp.filter((curr: ReservationSetUp, index: number, arr: ReservationSetUp[]) => {
    const firstIndex = arr.findIndex((item) => item.deskID === curr.deskID);
    
    return index === firstIndex && curr.officeID === selectedOfficeID && curr.floorID === selectedFloorID;

  })
  .map((reservationSetUp: ReservationSetUp) => ({
    officeID: reservationSetUp.officeID,
    officeName: reservationSetUp.officeName,
    floorID: reservationSetUp.floorID,
    floorName: reservationSetUp.floorName,
    deskID: reservationSetUp.deskID,
    deskName: reservationSetUp.deskName,
  }))
: [];

// const handleSubmit = ();
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "left",
        mt: 2,
      }}
    >
      <FormControl sx={{ width: "64ch", mb: 5 }}>
        <InputLabel id="select-office">Office</InputLabel>
        <Select
          labelId="select-office"
          id="select-office"
          value={selectedOfficeID}
          label="Office"
          // onChange={handleOfficeChange}
          disabled={!isDateCompleted || !isTimeCompleted}
          onChange={(event) => setSelectedOfficeID(event.target.value)}
        >
          {uniqueOffices?.map((reservationSetUp : ReservationSetUp, index: number) => (
            <MenuItem key={reservationSetUp.officeID} value={reservationSetUp.officeID}>
              {reservationSetUp.officeName}
            </MenuItem>
          ))} 
        </Select>
      </FormControl>

      <FormControl sx={{ width: "25ch", mb: 5, alignItems: "left" }}>
        <InputLabel id="select-floor">Floor</InputLabel>
        <Select
          labelId="select-floor"
          id="select-floor"
          value={selectedFloorID}
          label="Floor"
          // onChange={handleFloorChange}
          disabled={selectedOfficeID===""}
          onChange={(event) => setSelectedFloorID(event.target.value)}
        >
          {uniqueFloors?.map((reservationSetUp : ReservationSetUp, index: number) => (
            <MenuItem key={index} value={reservationSetUp.floorID}>
              {reservationSetUp.floorName}
            </MenuItem>
          ))} 
        </Select>
      </FormControl>

      <FormControl sx={{ width: "25ch", mb: 5, alignItems: "left" }}>
        <InputLabel id="select-desk">Desk</InputLabel>
        <Select
          labelId="select-desk"
          id="select-desk"
          value={selectedDeskID}
          label="Desk"
          onChange={(event) => setSelectedDeskID(event.target.value)}
          disabled={selectedFloorID===''}
        >
         {uniqueDesks?.map((reservationSetUp : ReservationSetUp, index: number) => (
            <MenuItem key={reservationSetUp.deskID} value={reservationSetUp.deskID}>
              {reservationSetUp.deskName}
            </MenuItem>
          ))} 
        </Select>
      </FormControl>
      <Button
      variant="contained"
      size="large"
      color="secondary"
      sx={{
        height: "50px",
        color: "white",
        textTransform: "none",
      }}
      onClick={createReservation}
      >
        Saved
      </Button>
    </Box>
  );
}

function ReserveDesk() {
  const [startTime, setStartTime] = React.useState<Dayjs | null>(dayjs()
  );
  const [endTime, setEndTime] = React.useState<Dayjs | null>(dayjs()
  );
  const [allDay, setAllDay] = React.useState<boolean>(false);
  const [value, setValue] = React.useState<Dayjs | null>(dayjs());

  const [isDateCompleted, setDateCompleted] = React.useState(false);
  const [isTimeCompleted, setTimeCompleted] = React.useState(false);

  const handleDateChange = (newValue: Dayjs | null) => {
    setValue(newValue);
    if (newValue) {
      setDateCompleted(true);
    } else {
      setDateCompleted(false);
    }
  };

  const handleAllDayToggle = (event: React.ChangeEvent<HTMLInputElement>) => {
    setAllDay(event.target.checked);
    if (event.target.checked) {
      setStartTime(dayjs().set("hour", 7).set("minute", 0));
      setEndTime(dayjs().set("hour", 18).set("minute", 0));
      setTimeCompleted(true);
    } else {
      setTimeCompleted(!!startTime && !!endTime);
    }
  };

  const handleStartTimeChange = (newValue: Dayjs | null) => {
    setStartTime(allDay ? null : newValue);
  };

  const handleEndTimeChange = (newValue: Dayjs | null) => {
    setEndTime(allDay ? null : newValue);
    if (newValue) {
      setTimeCompleted(true);
    } else {
      setTimeCompleted(false);
    }
  };

  const shouldDisableStartTime = (value: Dayjs, view: TimeView) => {
    if (view === "hours") {
      const startHour = startTime?.hour();
      const startMinute = startTime?.minute();
      if (startHour !== undefined && startMinute !== undefined) {
        const startTime = dayjs()
          .set("hour", startHour)
          .set("minute", startMinute)
          .startOf("minute");
        const endTime = dayjs().set("hour", 16).startOf("hour");
        return (
          value.isBefore(startTime, "hour") || value.isAfter(endTime, "hour")
        );
      }
    }
    if (view === "minutes") {
      const minute = value.minute();
      return minute !== 0 && minute !== 30;
    }
    return false;
  };
  const shouldDisableEndTime = (value: Dayjs, view: TimeView) => {
    if (view === "hours") {
      const startHour = startTime?.add(1, "hour").hour();
      const startMinute = startTime?.minute();
      if (startHour !== undefined && startMinute !== undefined) {
        const startTime = dayjs()
          .set("hour", startHour)
          .set("minute", startMinute)
          .startOf("minute");

        const endTime = dayjs().set("hour", 16).startOf("hour");
        return (
          value.isBefore(startTime, "hour") || value.isAfter(endTime, "hour")
        );
      }
    }
    if (view === "minutes") {
      const minute = value.minute();
      return minute !== 0 && minute !== 30;
    }
    return false;
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
        <AppBar position="fixed" sx={{ width: "100%" }}>
          <Toolbar disableGutters>
            <MobileFriendlyIcon
              sx={{
                display: { xs: "none", md: "flex" },
                mr: 1,
                fontSize: 40,
                marginLeft: 3,
              }}
            />{" "}
            <Typography variant="h6" component="div">
              Reserve a desk
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
            mb: 3,
          }}
        >
          <div></div>
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
              width: "100%",
              p: 2,
              mb: 2,
            }}
          ></Box>
          
        </Box>

        <DatePickerValue
          allDay={allDay}
          handleAllDayToggle={handleAllDayToggle}
          setValue={setValue}
          startTime={startTime}
          endTime={endTime}
          handleStartTimeChange={handleStartTimeChange}
          handleEndTimeChange={handleEndTimeChange}
          setDateCompleted={setDateCompleted}
          handleDateChange={handleDateChange}
          isTimeCompleted={isTimeCompleted}
        />

        {!allDay && (
          <div>
            <Box sx={{ display: "flex", mb: 3 }}>
              <DemoItem component="TimePicker">
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <div style={{ display: "flex", alignItems: "center" }}>
                    <>
                      <TimePicker
                        label="Start"
                        onChange={handleStartTimeChange}
                        shouldDisableTime={shouldDisableStartTime}
                        disabled={!isDateCompleted}
                        sx={{
                          "& .MuiOutlinedInput-root": {
                            borderColor: grey[900],
                            width: "18ch",
                          },
                          "& .MuiOutlinedInput-notchedOutline": {
                            borderColor: grey[900],
                          },
                          "& .MuiOutlinedInput-input": {
                            color: grey[900],
                          },
                        }}
                      />
                      <Typography
                        variant="body1"
                        component="span"
                        style={{ margin: "0 10px" }}
                      >
                        to
                      </Typography>
                      <TimePicker
                        label="End"
                        onChange={handleEndTimeChange}
                        shouldDisableTime={shouldDisableEndTime}
                        disabled={!isDateCompleted}
                        sx={{
                          "& .MuiOutlinedInput-root": {
                            borderColor: grey[900],
                            width: "18ch",
                          },
                          "& .MuiOutlinedInput-notchedOutline": {
                            borderColor: grey[900],
                          },
                          "& .MuiOutlinedInput-input": {
                            color: grey[900],
                          },
                        }}
                      />
                    </>
                  </div>
                </LocalizationProvider>
              </DemoItem>
            </Box>
          </div>
        )}
        <BasicSelect
          value={value}
          startTime={startTime}
          endTime={endTime}
          isDateCompleted={isDateCompleted}
          isTimeCompleted={isTimeCompleted}
        />
      </Box>
    </ThemeProvider>
  );
}

export default ReserveDesk;
