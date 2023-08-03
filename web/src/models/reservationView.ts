export interface ReservationView {
    reservationID : string;
    arrivalTime :Date ;
    leavingTime :Date;
    officaName : string;
    floorName : string;
    deskName :string;
    avatar: Uint8Array;
    profileRole : string;
    profileName : string;
  }