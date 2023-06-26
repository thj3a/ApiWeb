import logo from './logo.svg';
import './App.css';
import { Table } from "react-bootstrap";
import React, { Component, useState, useEffect } from 'react';

function App() {

  const port = 5000;
  const url = 'http://localhost:5000/dados';
  // const url = "https://datausa.io/api/data?drilldowns=Nation&measures=Population";
  const [data, setData] = useState([]);
  const [keys, setKeys] = useState([]);
  
  

  

  const handleButtonClick = (row) => {};


  useEffect(() => {
    // Função para realizar o fetch e atualizar o estado
    const fetchData = async () => {
      try {
        const response = await fetch(url);
        const dataJson = await response.json();
        const rawData = dataJson;
        setData(rawData);
      } catch (error) {
        console.error('Erro ao buscar os dados:', error);
      }
    };
  
    const fetchKeys = () => {
      try {
        setKeys(Object.keys(data[0]));
      } catch (error) {
        console.error('Erro ao setar as chaves:', error);
      }
    };
    fetchData(); // Chamando a função de busca dos dados
    fetchKeys();
  }, []); // Executado apenas uma vez ao montar o componente


  return (
    <div>
      <h1>Tabela de Alternativas</h1>
      <Table striped bordered hover>
        <thead>
          <tr>
            {keys.map(chave => <th key={chave}>{chave}</th>)}
            <th>Opções</th> {/* Cabeçalho para a coluna de opções */}
          </tr>
        </thead>
        <tbody>
          {data.map((row) => (
            <tr>
              {keys.map((key) => (
                <td key={key}>{row[key]}</td>
              ))}
              <td>
              <button onClick={() => handleButtonClick(row)}>Opção</button>
              </td> {/* Célula com o botão */}
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
    
  );
}

export default App;

