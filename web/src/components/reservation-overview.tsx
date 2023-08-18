import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import Avatar from "@mui/material/Avatar";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import TodayIcon from "@mui/icons-material/Today";
import { Button, Stack, Divider, TextField } from "@mui/material";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import CreateIcon from "@mui/icons-material/Create";
import DeleteIcon from "@mui/icons-material/Delete";
import Modal from "@mui/material/Modal";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import EditReservation from "./edit-reservation";
import ReserveDesk from "./reserve-a-desk";
import Settings from "./settings";
import { grey, orange } from "@mui/material/colors";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { ReservationView } from "../models/reservationView";
import { Profile } from "../models/profile";
import MobileFriendlyIcon from "@mui/icons-material/MobileFriendly";
import CloseIcon from "@mui/icons-material/Close";
import PersonOutlineIcon from "@mui/icons-material/PersonOutline";
import SettingsIcon from "@mui/icons-material/Settings";
import backgroundImage from "../assests/background.jpg"
const settings = ["My Profile", "Settings", "Logout"];

const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 1000,
  bgcolor: "background.paper",
  boxShadow: 24,
  borderRadius: 1,
  p: 4,
};

const styleSettings = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 500,
  height: 600,
  bgcolor: "background.paper",
  boxShadow: 5,
  borderRadius: 1,
  p: 3,
};
const backgroundImageStyle: React.CSSProperties = {
  backgroundImage: `url(${backgroundImage})`,
  backgroundRepeat: "no-repeat",
  backgroundSize: "cover",
  backgroundPosition: "center",
  opacity: 0.15,
  position: "fixed",
  top: 0,
  left: 0,
  width: "100%",
  height: "100%",
  zIndex: -1,
};
function ReservationOverview() {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(
    null
  );
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );
  // pt deschiderea meniului
  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const [openEdit, setOpenEdit] = React.useState(false);
  const [openDeleteForReservationId, setOpenDeleteForReservationId] = React.useState<string | null>(null);
  const [openReservationIdForEdit, setOpenReservationIdForEdit] =  useState<
  string | null
>(null);

const handleOpenDelete = (reservationId: string) => {
  setOpenDeleteForReservationId(reservationId);
};

const handleCloseDelete = () => {
  setOpenDeleteForReservationId(null);
};

  const handleOpenEdit = (reservationId: string) => {
    setOpenReservationIdForEdit(reservationId);
  };


  const handleCloseEdit = () => setOpenReservationIdForEdit(null);
  const [confirmation, setConfirmation] = useState(false);
  const navigate = useNavigate();
  const handleNo = () => {
    setOpenDeleteForReservationId(null);
    setConfirmation(false);
    setOpenEdit(false);
    navigate("/reservationoverview");
  };

  const [openReservation, setOpenReservation] = React.useState(false);
  const handleOpenReservation = () => {
    setOpenReservation(true);
  };
  const handleCloseReservation = () => {
    setOpenReservation(false);
  };

  const [openMyProfile, setOpenMyProfile] = React.useState(false);
  const handleOpenMyProfile = () => {
    setOpenMyProfile(true);
  };
  const handleCloseMyProfile = () => {
    setOpenMyProfile(false);
  };

  const [openSettings, setOpenSettingsModal] = React.useState(false);
  const handleOpenSettingsModal = () => {
    setOpenSettingsModal(true);
  };
  const handleCloseSettingsModal = () => {
    setOpenSettingsModal(false);
  };

  const [reservationViews, setReservationViews] = useState<
    ReservationView[] | null
  >(null);
  

  useEffect(() => {
    const fetchData = async () => {
      try {
        const token = localStorage.getItem("authToken");

        if (!token) {
          throw new Error("Authentication token not found in localStorage");
        }
        const response = await fetch(
          "https://localhost:7156/api/Reservation/GetAllProfileReservations",
          {
            method: "GET",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        if (!response.ok) {
          throw new Error("Network response was not ok");
        }

        const data = await response.json();
        setReservationViews(data);
      } catch (error) {
        console.error("Unknown error occurred:", error);
      }
    };
    fetchData();
  }, []);

  const [userProfile, setUserProfile] = useState<Profile | null>(null);
  useEffect(() => {
    const fetchUserProfile = async () => {
      try {
           const token = localStorage.getItem("authToken");
        if (!token) {
          throw new Error("Authentication token not found in localStorage");
        }
        const response = await fetch(
          "https://localhost:7156/api/Profile/GetProfile",
          {
            method: "GET",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        if (!response.ok) {
          throw new Error("Network response was not ok");
        }

        const data = await response.json();
        setUserProfile(data);
      } catch (error) {
        console.error("Unknown error occurred:", error);
      }
    };
    fetchUserProfile();
  }, []);

  const fetchDelete = async (reservationView: ReservationView) => {
    try {
      const token = localStorage.getItem("authToken");
      const id = reservationView.reservationID;
      if (!token) {
        throw new Error("Authentication token not found in localStorage");
      }
      const response = await fetch(`https://localhost:7156/api/Reservation/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      setReservationViews((prevData) => prevData?.filter((reservation) => reservation.reservationID !== id) || null);
    
    } catch (error) {
      console.error("Unknown error occurred:", error);
    }
  };

  const handleYes = (reservationView: ReservationView) => {
    fetchDelete(reservationView);
    
    console.log(reservationView);
    setConfirmation(true);
    setOpenEdit(false);
   };
  

   const handleLogout = () => {
    {
      localStorage.removeItem("authToken");
      localStorage.removeItem("authTokenExpiry");
      localStorage.clear();
    }
    navigate("/login");
  };
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
      fontSize: 15,
    },
  });


 function MyProfile() {

  const [firstName, setFirstName] = useState(userProfile?.firstName || '');
  const [lastName, setLastName] = useState(userProfile?.lastName || '');
  const [role, setRole] = useState(userProfile?.role || '');
  const [nickName, setNickName] = useState(userProfile?.nickName || '');
  const [emailAddress, setEmailAddress] = useState(userProfile?.emailAddress || '');


  const editProfile = async () => {
    const editedProfile ={
      firstName,
      lastName,
      role,
      nickName,
      avatar: userProfile?.avatar,
      emailAddress,
    }
   try{
      const token = localStorage.getItem("authToken");
      if (!token) {
        throw new Error("Invalid token");
      }
      const response = await fetch(`https://localhost:7156/api/Profile/PutProfile/EditProfile`, {
        method: "PUT",
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(editedProfile),
      });
      if(response.ok){
        window.location.reload();
      }
      else {
        throw new Error("Network response was not ok");
      }
    }
    catch (error) {
      console.error("Unknown error occurred:", error);
    }
  }

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
        <Stack direction="row" spacing={1.5}>
          <Avatar
            alt="V"
            src="/static/images/avatar/1.jpg"
            sx={{ width: 100, height: 100, ml: -28, mr: -25, mt: 15 }}
          />
        </Stack>
        <Box
         component="form"
         noValidate
         autoComplete="off"
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
            sx={{
              "& .MuiTextField-root": {
                mb: -5,
                width: "40ch",
                mt: 10,
                mr: -12,
              },
            }}
          >
             <TextField
              label="First Name"
              id="outlined-size-normal"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />

             <TextField
              label="Last Name"
              id="outlined-size-normal"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
            />

            <TextField
              label="Job title"
              id="outlined-size-normal"
              value={role}
              onChange={(e) => setRole(e.target.value)}
            />

            <TextField
              label="E-mail"
              defaultValue={userProfile?.emailAddress}
              variant="outlined"
              disabled
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
              label="Nickname"
              value={nickName}
              onChange={(e) => setNickName(e.target.value)}
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
                marginBottom: -40,
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
            }}
          type="submit"
          onClick={editProfile}
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


  return (
    <>
      <div style={backgroundImageStyle} />
      <ThemeProvider theme={theme}>
        <AppBar position="fixed">
          <Toolbar disableGutters>
            <TodayIcon
              sx={{
                display: { xs: "none", md: "flex" },
                mr: 1,
                fontSize: 40,
                marginLeft: 5,
              }}
            />{" "}
            <Typography
              variant="h4"
              noWrap
              component="a"
              sx={{
                mr: 2,
                display: { xs: "none", md: "flex" },
                fontFamily: "Segoe UI",
                fontWeight: 400,
                letterSpacing: ".1rem",
                color: "inherit",
                textDecoration: "none",
              }}
            >
              My Reservations
            </Typography>
            <TodayIcon
              sx={{ display: { xs: "flex", md: "none" }, mr: 1, fontSize: 40 }}
            />
            <Typography
              variant="h5"
              noWrap
              component="a"
              sx={{
                mr: 2,
                display: { xs: "flex", md: "none" },
                flexGrow: 1,
                fontFamily: "Segoe UI",
                fontWeight: 700,
                letterSpacing: ".3rem",
                color: "inherit",
                textDecoration: "none",
              }}
            >
              My Reservations
            </Typography>
            <Box
              sx={{ flexGrow: 1, display: { xs: "flex", md: "flex" } }}
            ></Box>
            <Box sx={{ flexGrow: 0, marginRight: 10 }}>
              <Stack direction="row" spacing={2} alignItems="center">
                <Tooltip title="Open settings">
                  <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                    <MoreVertIcon
                      sx={{ fontSize: 30, color: "white" }}
                    ></MoreVertIcon>
                  </IconButton>
                </Tooltip>
              </Stack>
            </Box>
            <Modal
              open={openSettings}
              onClose={handleCloseSettingsModal}
              aria-labelledby="modal-modal-title"
            >
              <Box sx={styleSettings}>
                <AppBar position="fixed" sx={{ width: "100%" }}>
                  <Toolbar disableGutters>
                    <SettingsIcon
                      sx={{
                        display: { xs: "none", md: "flex" },
                        mr: 1,
                        fontSize: 30,
                        marginLeft: 2,
                      }}
                    />{" "}
                    <Typography variant="h6" component="div">
                      Settings
                    </Typography>
                    <IconButton
                      sx={{ marginLeft: 44 }}
                      onClick={handleCloseSettingsModal}
                    >
                      <CloseIcon sx={{ color: "white" }} />
                    </IconButton>
                  </Toolbar>
                </AppBar>
                <Settings />
              </Box>
            </Modal>
            <Modal
              open={openMyProfile}
              aria-labelledby="modal-modal-title"
            >
              <Box sx={styleSettings}>
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
                    <IconButton
                      sx={{ marginLeft: 39 }}
                      onClick={handleCloseMyProfile}
                    >
                      <CloseIcon sx={{ color: "white" }} />
                    </IconButton>
                  </Toolbar>
                </AppBar>
                <MyProfile />
              </Box>
            </Modal>
            <Avatar
              alt="User Name"
              src={`data:image/png;base64,${userProfile?.avatar}`}
              sx={{ marginLeft: -9, marginRight: -1 }}
            />
            <Typography
              variant="h6"
              noWrap
              sx={{
                mr: 2,
                display: { xs: "none", md: "flex" },
                fontFamily: "Segoe UI",
                fontWeight: 400,
                letterSpacing: ".0rem",
                color: "#FFFFFF",
                textDecoration: "none",
                marginLeft: 2,
                marginTop: 0,
                padding: 1,
              }}
            >
              {userProfile?.nickName}
            </Typography>
            <Box
              margin={1}
              display="flex"
              justifyContent="flex-end"
              alignItems="flex-end"
              sx={{
                top: 100,
                right: "60%",
                marginRight: -100,
                position: "absolute",
              }}
            >
              <Box
                sx={{position:"sticky",
                 justifyContent: "flex-start",
                  mt: 10, 
                  marginBottom: 200,
                  zIndex: 1000}}
              >
                <Button
                  variant="contained" 
                  size="large"
                  color="secondary"
                  sx={{
                    
                    height: "50px",
                    color: "white",
                    textTransform: "none",
                  }}
                  onClick={handleOpenReservation}
                >
                  Make a reservation
                </Button>
              </Box>

              <Modal
                open={openReservation}
                
                aria-labelledby="modal-modal-title"
              >
                <Box sx={style}>
                  <AppBar position="fixed" sx={{ width: "100%" }}>
                    <Toolbar disableGutters>
                      <MobileFriendlyIcon
                        sx={{
                          display: { xs: "none", md: "flex" },
                          mr: 1,
                          fontSize: 35,
                          marginLeft: 3,
                        }}
                      />{" "}
                      <Typography variant="h6" component="div">
                        Reserve a desk
                      </Typography>
                      <IconButton
                        sx={{ marginLeft: 97 }}
                        onClick={handleCloseReservation}
                      >
                        <CloseIcon sx={{ color: "white" }} />
                      </IconButton>
                    </Toolbar>
                  </AppBar>
                  <ReserveDesk />
                </Box>
              </Modal>
            </Box>
            <Menu
              sx={{ mt: "45px" }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {settings.map((setting) => (
                <MenuItem
                  key={setting}
                  onClick={
                    setting === "Settings"
                      ? handleOpenSettingsModal
                      : setting === "Logout"
                      ? handleLogout
                      : setting === "My Profile"
                      ? handleOpenMyProfile
                      : handleCloseUserMenu
                  }
                >
                  <Typography textAlign="center">{setting}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Toolbar>
        </AppBar>

        <Box
          sx={{
            flexGrow: 1,
            marginTop: 35,
            marginLeft: "auto",
            marginRight: "auto",
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            flexDirection: "column",
          }}
        >
          {reservationViews?.length === 0 ? (
            <Typography variant="h6" color="textSecondary" sx={{ mt: 20 }}>
              No reservations found. To initiate the reservation process, click
              on the button "Make a reservation."
            </Typography>
          ) : (
            reservationViews?.map((reservationView: ReservationView) => (
              <React.Fragment key={reservationView.reservationID}>

                <Box marginTop={6}>
                  <Stack
                    direction="row"
                    spacing={5}
                    divider={<Divider orientation="vertical" flexItem />}
                    sx={{
                      backgroundColor: "rgba(128, 128, 128, 0.8)",
                      padding: "10px",
                      borderRadius: "4px",
                    }}
                  >
                    <Stack direction="row" alignItems="center" spacing={2}>
                      <Avatar
                        src={`data:image/png;base64,${reservationView.avatar}`}
                      />
                      <Stack direction="column">
                        <Typography
                          variant="h6"
                          marginRight={60}
                          alignItems="center"
                          color={"white"}
                        >
                          {reservationView.profileName}
                        </Typography>
                        <Typography
                          variant="h6"
                          sx={{
                            fontSize: 13,
                            marginRight: 72,
                          }}
                        >
                          {reservationView.profileRole}
                        </Typography>
                      </Stack>
                    </Stack>
                    <Stack direction="row" alignItems="center" spacing={10}>
                      <Stack direction="column" gap={2}>
                        <Typography
                          variant="h6"
                          sx={{ fontSize: 15, marginTop: 2, color: "white" }}
                          
                        >
                          Date: { reservationView.arrivalTime.slice(0,10)}
                        </Typography>
                        <Typography
                          variant="h6"
                          sx={{ fontSize: 15, marginTop: 2, color: "white" }}
                        >
                          Office: {reservationView.officaName}
                        </Typography>
                      </Stack>
                      <Stack direction="column" gap={2}>
                        <Typography
                          variant="h6"
                          sx={{ fontSize: 15, marginTop: 2, color: "white" }}
                        >
                          Interval: {reservationView.arrivalTime.slice(11,16)} - {reservationView.leavingTime.slice(11,16)}
                        </Typography>
                        <Typography
                          variant="h6"
                          sx={{
                            fontSize: 15,
                            marginTop: 2,
                            color: "white",
                          }}
                        >
                          Floor: {reservationView.floorName}
                        </Typography>
                      </Stack>
                      <Stack direction="column" alignItems="center" gap={2}>
                        <Typography
                          variant="h6"
                          sx={{ fontSize: 15, marginTop: 2 }}
                        ></Typography>
                        <Typography
                          variant="h6"
                          sx={{
                            fontSize: 15,
                            marginTop: 5,
                            color: "white",
                          }}
                        >
                          Desk: {reservationView.deskName}
                        </Typography>
                      </Stack>
                      <Box>
                        <Modal
                          open={openReservationIdForEdit === reservationView.reservationID}
                          onClose={handleCloseEdit}
                          aria-labelledby="modal-modal-title"
                        >
                          <Box sx={style}>
                            <AppBar position="fixed" sx={{ width: "100%" }}>
                              <Toolbar disableGutters>
                                <MobileFriendlyIcon
                                  sx={{
                                    display: { xs: "none", md: "flex" },
                                    mr: 1,
                                    fontSize: 35,
                                    marginLeft: 3,
                                  }}
                                />{" "}
                                <Typography variant="h6" component="div">
                                  Edit reservation
                                </Typography>
                                <IconButton
                                  sx={{ marginLeft: 97 }}
                                  onClick={handleCloseEdit}
                                >
                                  <CloseIcon sx={{ color: "white" }} />
                                </IconButton>
                              </Toolbar>
                            </AppBar>
                            
                            <EditReservation reservationID = {reservationView.reservationID}/>
                          </Box>
                        </Modal>
                      </Box>

                      <Stack direction="column" alignItems="center" gap={3}>
                        <Button onClick= {() => handleOpenEdit(reservationView.reservationID)}>
                          <CreateIcon
                            sx={{
                              marginTop: 2,
                              fontSize: 18,
                              color: "white",
                            }}
                          ></CreateIcon>
                        </Button>

                        <Button onClick={() => handleOpenDelete(reservationView.reservationID)}>
                          <DeleteIcon
                            sx={{
                              fontSize: 18,
                              color: orange[900],
                            }}
                          ></DeleteIcon>
                        </Button>
                        <Modal
                          open={openDeleteForReservationId === reservationView.reservationID}
                          onClose={handleCloseDelete}
                          aria-labelledby="modal-modal-title"
                          aria-describedby="modal-modal-description"
                        >
                          <Box sx={style}>
                            <Typography
                              id="modal-modal-title"
                              variant="h5"
                              component="h2"
                            >
                              My Reservations
                            </Typography>
                            <Typography
                              id="modal-modal-description"
                              sx={{ mt: 2 }}
                            >
                              Are you sure you want to delete this record?
                            </Typography>
                            <Box sx={{ marginTop: 2, marginLeft: 100 }}>
                              <Button onClick={handleNo}>Cancel</Button>
                              <Button  key={reservationView.reservationID}  onClick={() => handleYes(reservationView)}>Confirm</Button>
                            </Box>
                          </Box>
                        </Modal>
                      </Stack>
                    </Stack>
                  </Stack>
                </Box>
                </React.Fragment>
            ))
          )}
        </Box>
      </ThemeProvider>
    </>
  );}
                          //}
export default ReservationOverview;
