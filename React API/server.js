const express = require('express');
const ADODB = require('node-adodb');

const app = express();

app.use((req, res, next) => {
  res.setHeader('Access-Control-Allow-Origin', 'http://localhost:3000');
  res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
  next();
});
console.log(process.env.PARAMETER)
const connection = ADODB.open('Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FTQL_modified.mdb;');


app.get('/dados', (req, res) => {
  const query = 'SELECT * FROM ALTERNATIVAS';
  connection
  .query(query)
  .then(data => {
    res.json(data);
  })
  .catch(error => {
    console.error('Erro ao consultar o banco de dados:', error);
    res.status(500).json({ error: 'Erro ao consultar o banco de dados' });
  });
});

const port = 5000;
const url = "http://localhost:${port}/dados"
app.listen(port, () => {
  console.log(`API rodando em http://localhost:${port}`);
});