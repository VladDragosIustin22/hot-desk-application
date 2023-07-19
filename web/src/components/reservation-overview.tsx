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
import { Link } from "react-router-dom";
import { Button, Stack, Divider } from "@mui/material";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import CreateIcon from "@mui/icons-material/Create";
import DeleteIcon from "@mui/icons-material/Delete";
import Modal from "@mui/material/Modal";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
const settings = ["My Profile", "Settings", "Logout"];
const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};

function ReservationOverview() {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(
    null
  );
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );

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
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const [confirmation, setConfirmation] = useState(false);
  const navigate = useNavigate();
  const { id } = useParams();
  const handleNo = () => {
    setConfirmation(false);
    setOpen(false);
    navigate("/ReservationOverview");
  };
  const handleYes = () => {
    setConfirmation(true);
    setOpen(false);
    navigate("/ReservationOverview");
  };
  useEffect(() => {
    const DeleteReservation = async () => {
      if (confirmation) {
        const response = await fetch(
          `https://localhost:7155/api/Security/${id}`,
          {
            method: "DELETE",
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
          }
        );
      }
    };
    DeleteReservation();
  }, [id, confirmation]);

  return (
    <>
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
              fontFamily: "roboto",
              fontWeight: 700,
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
              fontFamily: "roboto",
              fontWeight: 700,
              letterSpacing: ".3rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            My Reservations
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "flex" } }}></Box>
          <Box sx={{ flexGrow: 0, marginRight: 10 }}>
            <Stack direction="row" spacing={2} alignItems="center">
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <MoreVertIcon sx={{ fontSize: 30 }}></MoreVertIcon>
                </IconButton>
              </Tooltip>

              <Avatar
                alt="User Name"
                src="/static/images/avatar/1.jpg"
                sx={{ marginLeft: 5, marginRight: -6 }}
              />

              <Typography
                variant="h6"
                noWrap
                sx={{
                  mr: 2,
                  display: { xs: "none", md: "flex" },
                  fontFamily: "roboto",
                  fontWeight: 700,
                  letterSpacing: ".0rem",
                  color: "#FFFFFF",
                  textDecoration: "none",
                  marginLeft: 2,
                  marginTop: 0,
                  padding: 1,
                }}
              >
                User Name
              </Typography>
            </Stack>
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
              <Button sx={{ mt: 3, mb: 2, backgroundColor: "#EC7329" }}>
                <Link
                  style={{ textDecoration: "none" }}
                  to={"/reserve-a-desk"}
                  color="#FFFFFF"
                >
                  Make a reservation
                </Link>
              </Button>
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
                <MenuItem key={setting} onClick={handleCloseUserMenu}>
                  <Typography textAlign="center">{setting}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>
        </Toolbar>
      </AppBar>
      <Box sx={{ flexGrow: 1, marginTop: 35, marginLeft: 20 }}>
        <Stack
          direction="row"
          spacing={2}
          divider={<Divider orientation="vertical" flexItem />}
        >
          <Stack direction="row" alignItems="center" spacing={2}>
            <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
            <Stack direction="column">
              <Typography variant="h6" marginRight={60} alignItems="center">
                Vlad Dragos
              </Typography>
              <Typography
                variant="h6"
                sx={{
                  fontSize: 13,
                  marginRight: 72,
                }}
              >
                Developer
              </Typography>
            </Stack>
          </Stack>
          <Stack direction="row" alignItems="center" spacing={10}>
            <Stack direction="column">
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 4 }}>
                Date: 05.07.2023
              </Typography>
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 4 }}>
                Office: Brizei
              </Typography>
            </Stack>
            <Stack direction="column">
              <Typography variant="h6" sx={{ fontSize: 15, marginTop: 4 }}>
                Interval: All day
              </Typography>
              <Typography
                variant="h6"
                sx={{
                  fontSize: 15,
                  marginTop: 4,
                }}
              >
                Floor: 1
              </Typography>
            </Stack>
            <Stack direction="column" alignItems="center">
              <Typography
                variant="h6"
                sx={{ fontSize: 15, marginTop: 4 }}
              ></Typography>
              <Typography
                variant="h6"
                sx={{
                  fontSize: 15,
                  marginTop: 7,
                }}
              >
                Desk: 2
              </Typography>
            </Stack>
            <Stack direction="column" alignItems="center">
              <CreateIcon
                onClick={(event) => (window.location.href = "/EditReservation")}
              ></CreateIcon>
              <Button onClick={handleOpen}>
                <DeleteIcon></DeleteIcon>
              </Button>
              <Modal
                open={open}
                onClose={handleClose}
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
                  <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                    Are you sure you want to delete this record?
                  </Typography>
                  <Box sx={{ marginTop: 2, marginLeft: 31 }}>
                    <Button onClick={handleNo}>Cancel</Button>
                    <Button onClick={handleYes}>Confirm</Button>
                  </Box>
                </Box>
              </Modal>
            </Stack>
          </Stack>
        </Stack>
      </Box>
    </>
  );
}
export default ReservationOverview;
