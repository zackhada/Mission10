import { useState, useEffect } from 'react';

function BowlerList() {
  const [bowlers, setBowlers] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5028/api/bowler')
      .then((response) => response.json())
      .then((data) => setBowlers(data))
      .catch((error) => console.error('Error fetching bowlers:', error));
  }, []);

  const formatName = (first, middle, last) => {
    return [first, middle, last].filter(Boolean).join(' ');
  };

  return (
    <div style={{ padding: '20px' }}>
      <table
        style={{
          width: '100%',
          borderCollapse: 'collapse',
          boxShadow: '0 2px 8px rgba(0,0,0,0.1)',
        }}
      >
        <thead>
          <tr style={{ backgroundColor: '#34495e', color: 'white' }}>
            <th style={thStyle}>Bowler Name</th>
            <th style={thStyle}>Team Name</th>
            <th style={thStyle}>Address</th>
            <th style={thStyle}>City</th>
            <th style={thStyle}>State</th>
            <th style={thStyle}>Zip</th>
            <th style={thStyle}>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler, index) => (
            <tr
              key={index}
              style={{
                backgroundColor: index % 2 === 0 ? '#f9f9f9' : 'white',
              }}
            >
              <td style={tdStyle}>
                {formatName(
                  bowler.bowlerFirstName,
                  bowler.bowlerMiddleInit,
                  bowler.bowlerLastName
                )}
              </td>
              <td style={tdStyle}>{bowler.teamName}</td>
              <td style={tdStyle}>{bowler.bowlerAddress}</td>
              <td style={tdStyle}>{bowler.bowlerCity}</td>
              <td style={tdStyle}>{bowler.bowlerState}</td>
              <td style={tdStyle}>{bowler.bowlerZip}</td>
              <td style={tdStyle}>{bowler.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

const thStyle = {
  padding: '12px 15px',
  textAlign: 'left',
  borderBottom: '2px solid #ddd',
};

const tdStyle = {
  padding: '10px 15px',
  borderBottom: '1px solid #ddd',
};

export default BowlerList;
