import "./App.css";
import { Box, Link, Typography } from "@mui/material";

function App() {
  return (
    <Box>
      <Typography variant="h2" align="center">
        Home Page
      </Typography>
      <Typography variant="h5" align="left">
        Choose where to go to:
        <Link href="/sign-up-page">Sign Up</Link>
      </Typography>
    </Box>
  );
}

export default App;
