class CommentBox extends React.Component {
    render() {
        return (
            <div className="commentBox">Hello, world! I am a Comment Box.</div>
        );
    }
}

ReactDOM.render(<CommentBox />, document.getElementById('content'));