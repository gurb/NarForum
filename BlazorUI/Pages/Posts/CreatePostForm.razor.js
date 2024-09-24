let content;
let showCode;
let filename;
let textData = "";

let active = false;


document.onload = function () {
	content = document.getElementById('content');
	showCode = document.getElementById('show-code');
	filename = document.getElementById('filename');

	content.addEventListener('mouseenter', function () {
		const a = content.querySelectorAll('a');
		a.forEach(item => {
			item.addEventListener('mouseenter', function () {
				content.setAttribute('contenteditable', false);
				item.target = '_blank';
			});
			item.addEventListener('mouseleave', function () {
				content.setAttribute('contenteditable', true);
			});
		})
	});

	showCode.addEventListener('click', function () {
		showCode.dataset.active = !active;
		active = !active
		if (active) {
			content.textContent = content.innerHTML;
			content.setAttribute('contenteditable', false);
		} else {
			content.innerHTML = content.textContent;
			content.setAttribute('contenteditable', true);
		}
	});
}

export function checkEnterCursorInQuote() {
	var selection = window.getSelection();
	var range = selection.getRangeAt(0);
	var blockquote = getParentBlockquote(range);
	content = document.getElementById('content');
	if (blockquote) {
		var evt = window.event || arguments.callee.caller.arguments[0];
		console.log(evt);
		evt.preventDefault();
		const selection = window.getSelection();
		const range = selection.getRangeAt(0);
		const newLine = document.createElement('div');
		newLine.innerHTML = "&nbsp;";

		selection.anchorNode.parentElement.insertAdjacentElement('afterend', newLine)
		range.setStart(newLine, 0);
		range.collapse(true);
		selection.removeAllRanges();
		selection.addRange(range);
		newLine.focus();
	}
}

export function checkDeleteCursorInQuote() {
	var selection = window.getSelection();
	var range = selection.getRangeAt(0);
	var blockquote = getParentBlockquote(range);
	if (blockquote) {
		var cursorPosition = window.getSelection().getRangeAt(0).startOffset; 
		selection.anchorNode.parentElement.innerHTML = removeHTMLCode(selection.anchorNode.parentElement.innerHTML);

		range.setStart(selection.anchorNode.firstChild, cursorPosition);
		range.collapse(true);
		selection.removeAllRanges();
		selection.addRange(range);
		selection.anchorNode.parentElement.focus();
	}
}


function removeHTMLCode(text) {
	return text.replace(/<[^>]*>?/gm, '');
}


export function checkClickInQuote() {
	var selection = window.getSelection();
	var range = selection.getRangeAt(0);
	var blockquote = getParentBlockquote(range);
	if (blockquote) {
		var evt = window.event || arguments.callee.caller.arguments[0];
		evt.preventDefault();
		var sel = window.getSelection();
		sel.removeAllRanges();
	}
}

function getParentBlockquote(range) {
	var node = range.commonAncestorContainer;
	while (node) {
		if (node.nodeName && node.nodeName.toUpperCase() === 'BLOCKQUOTE') {
			return node;
		}
		node = node.parentNode;
	}
	return null;
}

export function getData() {
	content = document.getElementById('content');

	return content.innerHTML;
}

export function setData(modelData) {
	content = document.getElementById('content');
	content.innerHTML = modelData;
}

export function formatDoc(cmd, value = null) {
	if (value) {
		document.execCommand(cmd, false, value);
	} else {
		document.execCommand(cmd);
	}
}

export function insertImage(url) {
	document.execCommand('insertImage', false, url);

	var img = document.querySelector('img[src="' + url + '"]');

	// Add the class to the image
	if (img) {
		img.classList.add('img-fluid');
	}

	document.execCommand('insertHTML', false, '<br><br>');
}

export function addLink() {
	const url = prompt('Insert url');
	formatDoc('createLink', url);

}

export function addImageUrls(urlList) {
	if (Array.isArray(urlList)) {
		for (var i = 0; i < urlList.length; i++) {
			insertImage(urlList[i]);
		}
	}
}


export function fileHandle(value, element) {
	content = document.getElementById('content');
	filename = document.getElementById('filename');

	if (value === 'new') {
		content.innerHTML = '';
		filename.value = 'untitled';
	} else if (value === 'txt') {
		const blob = new Blob([content.innerText])
		const url = URL.createObjectURL(blob)
		const link = document.createElement('a');
		link.href = url;
		link.download = `${filename.value}.txt`;
		link.click();
	}
}