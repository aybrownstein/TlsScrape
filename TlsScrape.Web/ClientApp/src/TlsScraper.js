import React, {useState, useEffect} from 'react';
import axios from 'axios';

const TlsScraper = () => {
    const [results, setResults] = useState([]);

    useEffect(() => {
        const scrapeTls = async () => {
            const {data} = await axios.get('/api/tlsscraper/scrape');
            setResults(data);
        }
        scrapeTls(); 
    },[]);

    return(
        <div className='row'>
            <div className='col-md-12'>
                {results.map(p => <div className='card'>
                    <img className='card-img-top' src={p.imageUrl}/>
                    <div className='card-body'>
                        <a href={p.linkUrl} target="_blank">
                            <h5 className='card-title'>{p.title}</h5>
                        </a>
                        <p className='card-text'>{p.blurb}</p>
                    </div>
                    </div>
                    )}
            </div>
        </div>
    )
 
}